using ConsoleApp;
using ConsoleApp.Services;
using NUnit.Framework;
using System;
using System.Linq;

namespace ConsoleAppTests.Services
{
    internal class SqlStructureReaderTests
    {
        [Test]
        public void ReadDataBaseStructure_ForSimpleFile_ShouldReturnCorrectStructure()
        {
            // Arrange
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\TestData\\DataReaderTestData\\data.csv";

            var sqlStructureReader = new SqlStructureCsvReader(new DatabaseStructureCreator(), new SqlStructureFormater());

            // Act
            var database =  sqlStructureReader.ReadDataBaseStructureFrom(fileName);

            // Assert
            var adventureDatabase = database.First(d => d.Name == "AdventureWorks2016_EXT");
            var northwindDatabase = database.First(d => d.Name == "Northwind");
            var baseballDatabase = database.First(d => d.Name == "BaseballData");

            var trackingEventTable = adventureDatabase.Tables.First(t => t.Name == "TrackingEvent");
            var salesTaxRateTable = adventureDatabase.Tables.First(t => t.Name == "SalesTaxRate");

            Assert.AreEqual(3, database.Count);
            Assert.AreEqual(0, northwindDatabase.Tables.Count);
            Assert.AreEqual(0, baseballDatabase.Tables.Count);
            Assert.AreEqual(2, adventureDatabase.Tables.Count);
            Assert.AreEqual(0, trackingEventTable.Columns.Count);
            Assert.AreEqual(1, salesTaxRateTable.Columns.Count);
        }
    }
}
