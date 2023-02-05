using ConsoleApp.Models;
using System.Collections.Generic;

namespace ConsoleApp.Interfaces
{
    public interface IDatabaseStructureCreator
    {
        void CreateStructure(SqlStructure sqlStructure);
        List<Database> GetCreatedStructure();
    }
}