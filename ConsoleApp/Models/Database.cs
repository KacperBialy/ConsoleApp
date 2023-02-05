using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public class Database : SqlInfoBase
    {
        public List<Table> Tables { get; set; } = new List<Table>();

        public Database(string name, string type) : base(name, type)
        {
        }
    }
}
