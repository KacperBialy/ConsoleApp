using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public class Table : SqlInfoBase
    {
        public string Schema { get; set; }
        public string ParentName { get; set; }
        public string ParentType { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();

        public Table(string name, string type) : base(name, type)
        {

        }
    }
}
