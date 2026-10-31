using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Data.Sqlite;

namespace BitMaster.Data
{
    internal static class Database
    {
        private const string SchemaScript = @"
CREATE TABLE IF NOT EXISTS Cars (
    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
    Brand       TEXT    NOT NULL CHECK (Brand IN ('KIA', 'Changan', 'Haval', 'Lada')),
    CarType     TEXT    NOT NULL CHECK (CarType IN ('Легковая', 'Грузовая', 'Автобус')),
    PlateNumber TEXT    NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS Drivers (
    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
    LastName        TEXT    NOT NULL,
    FirstName       TEXT    NOT NULL,
    MiddleName      TEXT    NULL,
    LicenseNumber   TEXT    NOT NULL UNIQUE
                    CHECK (LicenseNumber GLOB '[0-9][0-9][0-9][0-9] [0-9][0-9][0-9][0-9][0-9][0-9]'),
    ExperienceYears INTEGER NOT NULL CHECK (ExperienceYears >= 0)
);

CREATE TABLE IF NOT EXISTS Crews (
    Id       INTEGER PRIMARY KEY AUTOINCREMENT,
    CarId    INTEGER NOT NULL REFERENCES Cars(Id) ON DELETE RESTRICT,
    DriverId INTEGER NOT NULL REFERENCES Drivers(Id) ON DELETE RESTRICT,
    Active   INTEGER NOT NULL DEFAULT 1 CHECK (Active IN (0, 1))
);

CREATE UNIQUE INDEX IF NOT EXISTS UX_Crews_ActiveCar
    ON Crews(CarId) WHERE Active = 1;

CREATE UNIQUE INDEX IF NOT EXISTS UX_Crews_ActiveDriver
    ON Crews(DriverId) WHERE Active = 1;
";

        public static string DbPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bitmaster.db"); }
        }

        public static SqliteConnection OpenConnection()
        {
            var builder = new SqliteConnectionStringBuilder
            {
                DataSource = DbPath,
                Mode = SqliteOpenMode.ReadWriteCreate
            };

            var connection = new SqliteConnection(builder.ToString());
            connection.Open();

            using (var pragma = connection.CreateCommand())
            {
                pragma.CommandText = "PRAGMA foreign_keys = ON;";
                pragma.ExecuteNonQuery();
            }

            return connection;
        }

        public static void Initialize()
        {
            using (var connection = OpenConnection())
            using (var transaction = connection.BeginTransaction())
            {
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = SchemaScript;
                    command.ExecuteNonQuery();
                }

                SeedIfEmpty(connection, transaction);

                transaction.Commit();
            }
        }

        private static long CountRows(SqliteConnection connection, SqliteTransaction transaction, string table)
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = "SELECT COUNT(*) FROM " + table + ";";
                return (long)command.ExecuteScalar();
            }
        }

        private static void SeedIfEmpty(SqliteConnection connection, SqliteTransaction transaction)
        {
            // Заполняем только пустую базу, чтобы не дублировать данные при каждом запуске
            if (CountRows(connection, transaction, "Cars") > 0)
                return;

            var cars = new[]
            {
                new { Brand = "KIA",     CarType = "Легковая", PlateNumber = "А123БВ77" },
                new { Brand = "Changan", CarType = "Легковая", PlateNumber = "В456ГД77" },
                new { Brand = "Haval",   CarType = "Грузовая", PlateNumber = "Е789КЛ18" },
                new { Brand = "Lada",    CarType = "Легковая", PlateNumber = "М234НО63" },
                new { Brand = "KIA",     CarType = "Автобус",  PlateNumber = "О567ПР18" }
            };

            foreach (var car in cars)
            {
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = "INSERT INTO Cars (Brand, CarType, PlateNumber) VALUES ($brand, $type, $plate);";
                    command.Parameters.AddWithValue("$brand", car.Brand);
                    command.Parameters.AddWithValue("$type", car.CarType);
                    command.Parameters.AddWithValue("$plate", car.PlateNumber);
                    command.ExecuteNonQuery();
                }
            }

            var drivers = new[]
            {
                new { LastName = "Иванов",   FirstName = "Иван",    MiddleName = "Иванович",   LicenseNumber = "1234 567890", ExperienceYears = 10 },
                new { LastName = "Петров",   FirstName = "Пётр",    MiddleName = "Сергеевич",  LicenseNumber = "2345 678901", ExperienceYears = 5 },
                new { LastName = "Сидоров",  FirstName = "Алексей", MiddleName = "Петрович",   LicenseNumber = "3456 789012", ExperienceYears = 15 },
                new { LastName = "Смирнов",  FirstName = "Дмитрий", MiddleName = "Андреевич",  LicenseNumber = "4567 890123", ExperienceYears = 3 },
                new { LastName = "Кузнецов", FirstName = "Михаил",  MiddleName = "Олегович",   LicenseNumber = "5678 901234", ExperienceYears = 8 }
            };

            foreach (var driver in drivers)
            {
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = "INSERT INTO Drivers (LastName, FirstName, MiddleName, LicenseNumber, ExperienceYears) VALUES ($last, $first, $middle, $license, $exp);";
                    command.Parameters.AddWithValue("$last", driver.LastName);
                    command.Parameters.AddWithValue("$first", driver.FirstName);
                    command.Parameters.AddWithValue("$middle", driver.MiddleName);
                    command.Parameters.AddWithValue("$license", driver.LicenseNumber);
                    command.Parameters.AddWithValue("$exp", driver.ExperienceYears);
                    command.ExecuteNonQuery();
                }
            }

            // Экипажи: каждой машине — свой водитель (база пустая, поэтому Id идут с 1)
            for (int i = 1; i <= 5; i++)
            {
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = "INSERT INTO Crews (CarId, DriverId, Active) VALUES ($carId, $driverId, 1);";
                    command.Parameters.AddWithValue("$carId", i);
                    command.Parameters.AddWithValue("$driverId", i);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetCrews()
        {
            return LoadTable(@"
SELECT cr.Id,
       c.Brand || ' (' || c.PlateNumber || ')'                          AS [Машина],
       d.LastName || ' ' || d.FirstName
           || IFNULL(' ' || d.MiddleName, '')                          AS [Водитель],
       CASE WHEN cr.Active = 1 THEN 'Да' ELSE 'Нет' END                AS [Активен]
FROM Crews cr
JOIN Cars c    ON c.Id = cr.CarId
JOIN Drivers d ON d.Id = cr.DriverId
ORDER BY cr.Id;");
        }

        public static DataTable GetDrivers()
        {
            return LoadTable(@"
SELECT Id,
       LastName        AS [Фамилия],
       FirstName       AS [Имя],
       IFNULL(MiddleName, '') AS [Отчество],
       LicenseNumber   AS [Номер прав],
       ExperienceYears AS [Стаж, лет]
FROM Drivers
ORDER BY Id;");
        }

        public static DataTable GetCars()
        {
            return LoadTable(@"
SELECT Id,
       Brand       AS [Марка],
       CarType     AS [Тип],
       PlateNumber AS [Гос. номер]
FROM Cars
ORDER BY Id;");
        }

        private static DataTable LoadTable(string sql)
        {
            var table = new DataTable();

            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;

                using (var reader = command.ExecuteReader())
                {
                    var rows = new List<object[]>();
                    while (reader.Read())
                    {
                        var values = new object[reader.FieldCount];
                        reader.GetValues(values);
                        rows.Add(values);
                    }

                    // Тип колонки берём из первого непустого значения
                    // (у выражений в SQLite нет объявленного типа)
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Type columnType = typeof(string);
                        foreach (var row in rows)
                        {
                            if (row[i] != null && !(row[i] is DBNull))
                            {
                                columnType = row[i].GetType();
                                break;
                            }
                        }
                        table.Columns.Add(reader.GetName(i), columnType);
                    }

                    foreach (var row in rows)
                        table.Rows.Add(row);
                }
            }

            return table;
        }
    }
}
