using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using HandicraftApp.Models;
using HandicraftApp.Enums;

namespace HandicraftApp
{
    internal class Database
    {
        // Checks database for tables during startup and creates them if neccessary.
        public static void CreateDatabase()
        {
            //Table list.
            var tableNames = new List<TableNames>
            {
                TableNames.CrochetHooks,
                TableNames.CrochetThreads,
                TableNames.SewingThreads,
                TableNames.SewingFabrics,
                TableNames.SewingPatterns,
                TableNames.Misc
            };

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open(); //Open database connection.

                foreach (TableNames tableName in tableNames)
                {
                    string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";
                    string tableData = "";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader result = cmd.ExecuteReader())
                        {
                            //If result is empty create corresponding table.
                            if (!result.HasRows)
                            {
                                switch (tableName)
                                {
                                    case TableNames.SewingPatterns:
                                        tableData = $"CREATE TABLE {tableName} (id INTEGER PRIMARY KEY, patternModel VARCHAR(20), patternSizes VARCHAR(20), optionalInfo VARCHAR(20))";
                                        CreateTable(tableData, connection);
                                        break;
                                    case TableNames.SewingFabrics:
                                        tableData = $"CREATE TABLE {tableName} (id INTEGER PRIMARY KEY, mainType VARCHAR(20), subType VARCHAR(20), width REAL, height REAL)";
                                        CreateTable(tableData, connection);
                                        break;
                                    case TableNames.SewingThreads:
                                        tableData = $"CREATE TABLE {tableName} (id INTEGER PRIMARY KEY, colour VARCHAR(20), optionalInfo VARCHAR(20))";
                                        CreateTable(tableData, connection);
                                        break;
                                    case TableNames.CrochetHooks:
                                        tableData = $"CREATE TABLE {tableName} (id INTEGER PRIMARY KEY, size REAL, material VARCHAR(20))";
                                        CreateTable(tableData, connection);
                                        break;
                                    case TableNames.CrochetThreads:
                                        tableData = $"CREATE TABLE {tableName} (id INTEGER PRIMARY KEY, size REAL, material VARCHAR(20), colour VARCHAR(20))";
                                        CreateTable(tableData, connection);
                                        break;
                                    case TableNames.Misc:
                                        tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, name VARCHAR(20), optionalInfo VARCHAR(20))";
                                        CreateTable(tableData, connection);
                                        break;
                                }
                                try
                                {
                                    CreateTable(tableData, connection);
                                }
                                catch (Exception ex) 
                                { 
                                    Debug.WriteLine(ex);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Creates a new table.
        private static void CreateTable(string tableData, SQLiteConnection connection)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(tableData, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // Adds a new entry to a table and return item id.
        public static void AddTableEntry(string tableEntry)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(tableEntry, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                
                //using (SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid()", connection))
                //{
                //    long lastRow = (long)cmd.ExecuteScalar();
                //    return lastRow;
                //}
            }
        }

        // Gets table data and presents it according to the table columns.
        // Used when showing data from database.
        public static List<Item> GetTableData(TableNames tableName)
        {
            Item item;
            var items = new List<Item>();
            string query = $"SELECT * FROM {tableName}";

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        //Print results from database.
                        while (reader.Read())
                        {
                            switch (tableName)
                            {
                                case TableNames.SewingPatterns:
                                    item = new Item((long)reader["id"], reader["patternModel"].ToString(), reader["patternSizes"].ToString(), reader["optionalInfo"].ToString(), tableName);
                                    items.Add(item);
                                    break;
                                case TableNames.SewingFabrics:
                                    item = new Item((long)reader["id"], reader["mainType"].ToString(), reader["subType"].ToString(), (double)reader["width"], (double)reader["height"], tableName);
                                    items.Add(item);
                                    break;
                                case TableNames.SewingThreads:
                                    item = new Item((long)reader["id"], reader["colour"].ToString(), reader["optionalInfo"].ToString(), tableName);
                                    items.Add(item);
                                    break;
                                case TableNames.CrochetHooks:
                                    item = new Item((long)reader["id"], (double) reader["size"], reader["material"].ToString(), tableName);
                                    items.Add(item);
                                    break;
                                case TableNames.CrochetThreads:
                                    item = new Item((long)reader["id"], (double)reader["size"], reader["material"].ToString(), reader["colour"].ToString(), tableName);
                                    items.Add(item);
                                    break;
                                //case "misc":
                                //    Console.WriteLine($"Nimi: {reader["name"]} / Lisätietoja: {reader["optionalInfo"]}");
                                //    Console.WriteLine("- - - - - -");
                                //    break;
                                default:
                                    Debug.WriteLine("No data found");
                                    break;
                            }
                        }
                        return items;
                    }
                }
            }
        }

        // Removes data from a given table based on the item id.
        public static void RemoveTableData(TableNames tableName, long id)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                string query = $"DELETE FROM {tableName} WHERE id = '{id}'";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();

                    using (SQLiteCommand vacuum = new SQLiteCommand("VACUUM", connection))
                    {
                        vacuum.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
