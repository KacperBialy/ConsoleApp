using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    public class SqlStructureCsvReader
    {
        private readonly IDatabaseStructureCreator _databaseStructureGenerator;
        private readonly ISqlStructureFormater _sqlStructureFormater;

        public SqlStructureCsvReader(IDatabaseStructureCreator databaseStructureCreator, ISqlStructureFormater dataFromater)
        {
            _databaseStructureGenerator = databaseStructureCreator;
            _sqlStructureFormater = dataFromater;
        }

        public ICollection<Database> ReadDataBaseStructureFrom(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    var values = streamReader.ReadLine()
                            .Split(';');

                    if (!Validate(values))
                        continue;

                    var sqlStructure = CreateSqlStructureFromValues(values);
                    _databaseStructureGenerator.CreateStructure(sqlStructure);
                }
            }

            return _databaseStructureGenerator.GetCreatedStructure();
        }

        private bool Validate(string[] values)
        {
            if (values.Length == 7)
                return true;

            return false;
        }

        private SqlStructure CreateSqlStructureFromValues(string[] values)
        {
            return new SqlStructure()
            {
                Type = _sqlStructureFormater.FormatType(values[0]),
                Name = _sqlStructureFormater.Format(values[1]),
                Schema = _sqlStructureFormater.Format(values[2]),
                ParentName = _sqlStructureFormater.Format(values[3]),
                ParentType = _sqlStructureFormater.FormatType(values[4]),
                DataType = _sqlStructureFormater.Format(values[5]),
                IsNullable = _sqlStructureFormater.Format(values[6]),
            };
        }
    }
}
