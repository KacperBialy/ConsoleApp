using ConsoleApp;
using ConsoleApp.Interfaces;
using NUnit.Framework;

namespace ConsoleAppTests.Services
{
    public class DataFormaterTests
    {
        private ISqlStructureFormater _sqlStructureFormater;

        [SetUp]
        public void Init()
        {
            _sqlStructureFormater = new SqlStructureFormater();
        }

        [TestCase(" Adventure", "Adventure")]
        [TestCase(" Adventure ", "Adventure")]
        [TestCase(" Adv enture ", "Adv enture")]
        [TestCase(" Adv enture \n\n", "Adv enture")]
        public void Format_ForSpecificInput_ShouldReturnExpectedValue(string input, string expected)
        {
            // Act
            var output = _sqlStructureFormater.Format(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestCase(" Table", "TABLE")]
        [TestCase(" table ", "TABLE")]
        [TestCase(" tAbLE", "TABLE")]
        [TestCase(" tAbLE\n\n", "TABLE")]
        public void FormatType_ForSpecificInput_ShouldReturnExpectedValue(string input, string expected)
        {
            // Act
            var output = _sqlStructureFormater.FormatType(input);

            // Assert
            Assert.AreEqual(expected, output);
        }
    }
}
