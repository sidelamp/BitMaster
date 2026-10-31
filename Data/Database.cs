using System;
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
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = SchemaScript;
                command.ExecuteNonQuery();
                transaction.Commit();
            }
        }
    }
}
