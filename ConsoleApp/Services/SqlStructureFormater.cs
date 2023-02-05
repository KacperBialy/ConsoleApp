using ConsoleApp.Interfaces;

namespace ConsoleApp
{
    public class SqlStructureFormater : ISqlStructureFormater
    {
        public string FormatType(string value) => value.Trim().ToUpper();
        public string Format(string value) => value.Trim();
    }
}