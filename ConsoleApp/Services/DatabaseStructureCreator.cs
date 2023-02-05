using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Services
{
    public class DatabaseStructureCreator : IDatabaseStructureCreator
    {
        private readonly List<Database> databases = new List<Database>();
        private readonly List<Table> tempTables = new List<Table>();

        public List<Database> GetCreatedStructure()
        {
            return databases;
        }

        public void CreateStructure(SqlStructure sqlStructure)
        {
            switch (sqlStructure.Type)
            {
                case "DATABASE":
                    CreateDatabaseStructure(sqlStructure);
                    break;

                case "TABLE":
                    CreateTableStructure(sqlStructure);
                    break;

                case "COLUMN":
                    CreateColumnStructure(sqlStructure);
                    break;
            }
        }

        private void CreateDatabaseStructure(SqlStructure sqlStructure)
        {
            var database = databases.FirstOrDefault(d => d.Name == sqlStructure.Name);
            if (database == null)
            {
                database = new Database(sqlStructure.Name, sqlStructure.Type);
                databases.Add(database);
            }
        }

        private void CreateTableStructure(SqlStructure sqlStructure)
        {
            var database = databases.FirstOrDefault(d => d.Name == sqlStructure.ParentName);
            if (database == null)
            {
                database = new Database(sqlStructure.ParentName, sqlStructure.ParentType);
                databases.Add(database);
            }

            var table = tempTables.FirstOrDefault(t => t.Name == sqlStructure.Name);
            if (table == null)
            {
                table = new Table(sqlStructure.Name, sqlStructure.Type)
                {
                    Schema = sqlStructure.Schema,
                    ParentName = sqlStructure.ParentName,
                    ParentType = sqlStructure.ParentType
                };

            }
            else
                UpdateTable(sqlStructure, table);

            tempTables.Add(table);
            database.Tables.Add(table);
        }

        private static void UpdateTable(SqlStructure sqlStructure, Table table)
        {
            table.Schema = sqlStructure.Schema;
            table.ParentName = sqlStructure.ParentName;
            table.ParentType = sqlStructure.ParentType;
        }

        private void CreateColumnStructure(SqlStructure sqlStructure)
        {
            var column = new Column(sqlStructure.Name, sqlStructure.Type, sqlStructure.Schema, sqlStructure.ParentName,
                    sqlStructure.ParentType, sqlStructure.DataType, sqlStructure.IsNullable);

            var table = tempTables.FirstOrDefault(d => d.Name == sqlStructure.ParentName);
            if (table == null)
            {
                table = new Table(sqlStructure.ParentName, sqlStructure.ParentType);
                tempTables.Add(table);
            }

            table.Columns.Add(column);
        }
    }
}
