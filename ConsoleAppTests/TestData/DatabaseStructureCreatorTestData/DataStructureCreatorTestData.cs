using ConsoleApp.Models;

namespace ConsoleAppTests.TestData.DatabaseStructureCreatorTestData
{
    internal class DataStructureCreatorTestData
    {
        public static SqlStructure GetTableStructure()
        {
            return new SqlStructure()
            {
                Type = "TABLE",
                Name = "TableName",
                ParentName = "DatabaseName",
                ParentType = "DATABASE"
            };
        }

        public static SqlStructure GetColumnStructure()
        {
            return new SqlStructure()
            {
                Type = "COLUMN",
                Name = "ColumnName",
                ParentName = "TableName",
                ParentType = "TABLE"
            };
        }

        public static SqlStructure GetDatabaseStructure()
        {
            return new SqlStructure()
            {
                Type = "DATABASE",
                Name = "DatabaseName",
            };
        }
    }
}
