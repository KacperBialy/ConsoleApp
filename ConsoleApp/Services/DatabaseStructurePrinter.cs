using ConsoleApp.Models;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class DatabaseStructurePrinter
    {
        public void PrintDatabaseStructure(Database database)
        {
            Console.WriteLine($"Database '{database.Name}' ({database.Tables.Count} tables)");

            foreach (var table in database.Tables)
            {
                Console.WriteLine($"\tTable '{table.Schema}.{table.Name}' {table.Columns.Count} columns)");

                foreach (var column in table.Columns)
                {
                    Console.WriteLine($"\t\tColumn '{column.Name}' with {column.DataType} data type"
                        + $" {(column.IsNullable == "1" ? "accepts nulls" : "with no nulls")}");
                }
            }
        }

        public void PrintDatabaseStructures(IEnumerable<Database> databases)
        {
            foreach (var database in databases)
                PrintDatabaseStructure(database);
        }
    }
}
