namespace ConsoleApp.Models
{
    public class SqlInfoBase
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public SqlInfoBase(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}