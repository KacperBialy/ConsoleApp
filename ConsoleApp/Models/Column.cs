namespace ConsoleApp.Models
{
    public class Column : SqlInfoBase
    {
        public string Schema { get; }
        public string ParentName { get; }
        public string ParentType { get; }
        public string DataType { get; }
        public string IsNullable { get; }

        public Column(string name, string type, string schema, string parentName, string parentType, string dataType,
            string isNullable) : base(name, type)
        {
            Schema = schema;
            ParentName = parentName;
            ParentType = parentType;
            DataType = dataType;
            IsNullable = isNullable;
        }
    }
}
