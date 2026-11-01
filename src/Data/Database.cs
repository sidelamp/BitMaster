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

        // ---------- Машины ----------

        public static Car GetCar(int id)
        {
            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, Brand, CarType, PlateNumber FROM Cars WHERE Id = $id;";
                command.Parameters.AddWithValue("$id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new Car
                    {
                        Id = reader.GetInt32(0),
                        Brand = reader.GetString(1),
                        CarType = reader.GetString(2),
                        PlateNumber = reader.GetString(3)
                    };
                }
            }
        }

        public static List<Car> GetCarList()
        {
            var list = new List<Car>();

            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, Brand, CarType, PlateNumber FROM Cars ORDER BY Brand, PlateNumber;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Car
                        {
                            Id = reader.GetInt32(0),
                            Brand = reader.GetString(1),
                            CarType = reader.GetString(2),
                            PlateNumber = reader.GetString(3)
                        });
                    }
                }
            }

            return list;
        }

        public static void SaveCar(Car car)
        {
            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                if (car.Id < 0)
                {
                    command.CommandText = "INSERT INTO Cars (Brand, CarType, PlateNumber) VALUES ($brand, $type, $plate);";
                }
                else
                {
                    command.CommandText = "UPDATE Cars SET Brand = $brand, CarType = $type, PlateNumber = $plate WHERE Id = $id;";
                    command.Parameters.AddWithValue("$id", car.Id);
                }

                command.Parameters.AddWithValue("$brand", car.Brand);
                command.Parameters.AddWithValue("$type", car.CarType);
                command.Parameters.AddWithValue("$plate", car.PlateNumber);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteCar(int id)
        {
            DeleteById("Cars", id);
        }

        // Свободные машины: без активного экипажа.
        // exceptCrewId — экипаж, который игнорируем (при редактировании его машина тоже доступна)
        public static List<Car> GetFreeCarList(int exceptCrewId)
        {
            var list = new List<Car>();

            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
SELECT Id, Brand, CarType, PlateNumber
FROM Cars c
WHERE NOT EXISTS (
    SELECT 1 FROM Crews cr
    WHERE cr.CarId = c.Id AND cr.Active = 1 AND cr.Id <> $except)
ORDER BY Brand, PlateNumber;";
                command.Parameters.AddWithValue("$except", exceptCrewId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Car
                        {
                            Id = reader.GetInt32(0),
                            Brand = reader.GetString(1),
                            CarType = reader.GetString(2),
                            PlateNumber = reader.GetString(3)
                        });
                    }
                }
            }

            return list;
        }

        // ---------- Водители ----------

        public static Driver GetDriver(int id)
        {
            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, LastName, FirstName, MiddleName, LicenseNumber, ExperienceYears FROM Drivers WHERE Id = $id;";
                command.Parameters.AddWithValue("$id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new Driver
                    {
                        Id = reader.GetInt32(0),
                        LastName = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        MiddleName = reader.IsDBNull(3) ? null : reader.GetString(3),
                        LicenseNumber = reader.GetString(4),
                        ExperienceYears = reader.GetInt32(5)
                    };
                }
            }
        }

        public static List<Driver> GetDriverList()
        {
            var list = new List<Driver>();

            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, LastName, FirstName, MiddleName, LicenseNumber, ExperienceYears FROM Drivers ORDER BY LastName, FirstName;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Driver
                        {
                            Id = reader.GetInt32(0),
                            LastName = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            MiddleName = reader.IsDBNull(3) ? null : reader.GetString(3),
                            LicenseNumber = reader.GetString(4),
                            ExperienceYears = reader.GetInt32(5)
                        });
                    }
                }
            }

            return list;
        }

        public static void SaveDriver(Driver driver)
        {
            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                if (driver.Id < 0)
                {
                    command.CommandText = "INSERT INTO Drivers (LastName, FirstName, MiddleName, LicenseNumber, ExperienceYears) VALUES ($last, $first, $middle, $license, $exp);";
                }
                else
                {
                    command.CommandText = "UPDATE Drivers SET LastName = $last, FirstName = $first, MiddleName = $middle, LicenseNumber = $license, ExperienceYears = $exp WHERE Id = $id;";
                    command.Parameters.AddWithValue("$id", driver.Id);
                }

                command.Parameters.AddWithValue("$last", driver.LastName);
                command.Parameters.AddWithValue("$first", driver.FirstName);
                command.Parameters.AddWithValue("$middle",
                    string.IsNullOrWhiteSpace(driver.MiddleName) ? (object)System.DBNull.Value : driver.MiddleName.Trim());
                command.Parameters.AddWithValue("$license", driver.LicenseNumber);
                command.Parameters.AddWithValue("$exp", driver.ExperienceYears);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteDriver(int id)
        {
            DeleteById("Drivers", id);
        }

        // Свободные водители: без активного экипажа.
        // exceptCrewId — экипаж, который игнорируем (при редактировании его водитель тоже доступен)
        public static List<Driver> GetFreeDriverList(int exceptCrewId)
        {
            var list = new List<Driver>();

            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
SELECT Id, LastName, FirstName, MiddleName, LicenseNumber, ExperienceYears
FROM Drivers d
WHERE NOT EXISTS (
    SELECT 1 FROM Crews cr
    WHERE cr.DriverId = d.Id AND cr.Active = 1 AND cr.Id <> $except)
ORDER BY LastName, FirstName;";
                command.Parameters.AddWithValue("$except", exceptCrewId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Driver
                        {
                            Id = reader.GetInt32(0),
                            LastName = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            MiddleName = reader.IsDBNull(3) ? null : reader.GetString(3),
                            LicenseNumber = reader.GetString(4),
                            ExperienceYears = reader.GetInt32(5)
                        });
                    }
                }
            }

            return list;
        }

        // ---------- Экипажи ----------

        public static Crew GetCrew(int id)
        {
            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, CarId, DriverId, Active FROM Crews WHERE Id = $id;";
                command.Parameters.AddWithValue("$id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new Crew
                    {
                        Id = reader.GetInt32(0),
                        CarId = reader.GetInt32(1),
                        DriverId = reader.GetInt32(2),
                        Active = reader.GetInt32(3) == 1
                    };
                }
            }
        }

        public static void SaveCrew(Crew crew)
        {
            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                if (crew.Id < 0)
                {
                    command.CommandText = "INSERT INTO Crews (CarId, DriverId, Active) VALUES ($carId, $driverId, $active);";
                }
                else
                {
                    command.CommandText = "UPDATE Crews SET CarId = $carId, DriverId = $driverId, Active = $active WHERE Id = $id;";
                    command.Parameters.AddWithValue("$id", crew.Id);
                }

                command.Parameters.AddWithValue("$carId", crew.CarId);
                command.Parameters.AddWithValue("$driverId", crew.DriverId);
                command.Parameters.AddWithValue("$active", crew.Active ? 1 : 0);
                int affected = command.ExecuteNonQuery();

                // При обновлении запись могла быть уже удалена фоновой очисткой
                if (crew.Id >= 0 && affected == 0)
                    throw new InvalidOperationException("Crew " + crew.Id + " was already deleted.");
            }
        }

        public static void DeleteCrew(int id)
        {
            // 0 строк — запись уже удалена фоновой очисткой
            if (DeleteById("Crews", id) == 0)
                throw new InvalidOperationException("Crew " + id + " was already deleted.");
        }

        /// <summary>Удаляет все неактивные экипажи. Возвращает число удалённых записей.</summary>
        public static int DeleteInactiveCrews()
        {
            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Crews WHERE Active = 0;";
                return command.ExecuteNonQuery();
            }
        }

        private static int DeleteById(string table, int id)
        {
            using (var connection = OpenConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM " + table + " WHERE Id = $id;";
                command.Parameters.AddWithValue("$id", id);
                return command.ExecuteNonQuery();
            }
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
