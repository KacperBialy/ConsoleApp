using ConsoleApp;
using ConsoleApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleAppTests.Services
{
    internal class DatabaseStructurePrinterTests
    {
        [Test]
        public void PrintDatabaseStructure_ForDatabaseWithOneTableWithOneColumnStructure_ShouldPrintCorrectMessages()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var dataPrinter = new DatabaseStructurePrinter();

            var database = new Database("DatabaseName", "DATABASE")
            {
                Tables = new List<Table>()
                {
                    new Table("TableName", "TABLE")
                    {
                        Schema = "Production",
                        Columns= new List<Column>()
                        {
                            new Column("ColumnName", "Column", "Production", "TableName", "TABLE", "int", "1")
                        }
                    }
                }
            };

            // Act
            dataPrinter.PrintDatabaseStructure(database);

            // Assert
            Assert.AreEqual("Database 'DatabaseName' (1 tables)\r\n" +
                "\tTable 'Production.TableName' 1 columns)\r\n" +
                "\t\tColumn 'ColumnName' with int data type accepts nulls\r\n", stringWriter.ToString());
        }
    }
}
