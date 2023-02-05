using ConsoleApp.Interfaces;
using ConsoleApp.Services;
using ConsoleAppTests.TestData.DatabaseStructureCreatorTestData;
using NUnit.Framework;

namespace ConsoleAppTests.Services
{
    public class DatabaseStructureCreatorTests
    {
        private IDatabaseStructureCreator _databaseStructureCreator;

        [SetUp]
        public void Init()
        {
            _databaseStructureCreator = new DatabaseStructureCreator();
        }

        [Test]
        public void CreateStructure_ForDatabaseType_ShouldCreateDatabaseStructure()
        {
            // Arrange
            var databaseStructure = DataStructureCreatorTestData.GetTableStructure();

            // Act
            _databaseStructureCreator.CreateStructure(databaseStructure);
            var databases = _databaseStructureCreator.GetCreatedStructure();

            // Act
            Assert.AreEqual(1, databases.Count);
            Assert.AreEqual("DatabaseName", databases[0].Name);
            Assert.AreEqual("DATABASE", databases[0].Type);
        }

        [Test]
        public void CreateStructure_ForTableType_ThenForDatabaseType_ShouldCreateOneDatabaseStructure()
        {
            // Arrange
            var tableStructure = DataStructureCreatorTestData.GetTableStructure();
            var databaseStructure = DataStructureCreatorTestData.GetDatabaseStructure();

            // Act
            _databaseStructureCreator.CreateStructure(tableStructure);
            _databaseStructureCreator.CreateStructure(databaseStructure);
            var databases = _databaseStructureCreator.GetCreatedStructure();

            // Act
            Assert.AreEqual(1, databases.Count);
            Assert.AreEqual("DatabaseName", databases[0].Name);
            Assert.AreEqual("DATABASE", databases[0].Type);
        }

        [Test]
        public void CreateStructure_ForDatabaseTypeTwoTimes_ShouldCreateOneDatabaseStructure()
        {
            // Arrange
            var databaseStructure = DataStructureCreatorTestData.GetDatabaseStructure();

            // Act
            _databaseStructureCreator.CreateStructure(databaseStructure);
            _databaseStructureCreator.CreateStructure(databaseStructure);
            var databases = _databaseStructureCreator.GetCreatedStructure();

            // Act
            Assert.AreEqual(1, databases.Count);
            Assert.AreEqual("DatabaseName", databases[0].Name);
            Assert.AreEqual("DATABASE", databases[0].Type);
        }

        [Test]
        public void CreateStructure_ForTableType_ShouldCreateDatabaseWithOneTableStructure()
        {
            // Arrange
            var tableStructure = DataStructureCreatorTestData.GetTableStructure();

            // Act
            _databaseStructureCreator.CreateStructure(tableStructure);
            var databases = _databaseStructureCreator.GetCreatedStructure();

            // Act
            Assert.AreEqual(1, databases.Count);
            Assert.AreEqual("DatabaseName", databases[0].Name);
            Assert.AreEqual("DATABASE", databases[0].Type);
            Assert.AreEqual(1, databases[0].Tables.Count);
            Assert.AreEqual("TableName", databases[0].Tables[0].Name);
            Assert.AreEqual("TABLE", databases[0].Tables[0].Type);
        }

        [Test]
        public void CreateStructure_ForColumnType_ShouldReturnEmptyStructure()
        {
            // Arrange
            var columnStructure = DataStructureCreatorTestData.GetColumnStructure();

            // Act
            _databaseStructureCreator.CreateStructure(columnStructure);
            var databases = _databaseStructureCreator.GetCreatedStructure();

            // Act
            Assert.AreEqual(0, databases.Count);
        }

        [Test]
        public void CreateStructure_ForColumnType_ThenForTableType_ShouldCreateDatabaseWithTableWithColumn()
        {
            // Arrange
            var columnStructure = DataStructureCreatorTestData.GetColumnStructure();
            var tableStructure = DataStructureCreatorTestData.GetTableStructure();

            // Act
            _databaseStructureCreator.CreateStructure(columnStructure);
            _databaseStructureCreator.CreateStructure(tableStructure);
            var databases = _databaseStructureCreator.GetCreatedStructure();

            // Act
            var tables = databases[0].Tables;
            var columns = tables[0].Columns;

            Assert.AreEqual(1, databases.Count);
            Assert.AreEqual("DatabaseName", databases[0].Name);
            Assert.AreEqual("DATABASE", databases[0].Type);
            Assert.AreEqual(1, tables.Count);
            Assert.AreEqual("TableName", tables[0].Name);
            Assert.AreEqual("TABLE", tables[0].Type);
            Assert.AreEqual("ColumnName", columns[0].Name);
            Assert.AreEqual("COLUMN", columns[0].Type);
            Assert.AreEqual(1, columns.Count);
        }
    }
}