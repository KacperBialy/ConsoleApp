using ConsoleApp.Services;
using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Proszę podać nazwę pliku jako argument.");
                return;
            }

            StartProgram(fileName: args[0]);
        }

        private static void StartProgram(string fileName)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var databaseStructureCreator = new DatabaseStructureCreator();
            var dataFormater = new SqlStructureFormater();
            var sqlStructureCsvReader = new SqlStructureCsvReader(databaseStructureCreator, dataFormater);

            var dataPrinter = new DatabaseStructurePrinter();

            try
            {
                var databases = sqlStructureCsvReader.ReadDataBaseStructureFrom(fileName);

                dataPrinter.PrintDatabaseStructures(databases);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Nie znaleziono pliku o nazwie {fileName}");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine($"Brak pamięci na wykonanie programu.");
            }
            catch (Exception)
            {
                Console.WriteLine("Coś poszło nie tak.");
            }

            Console.WriteLine(stopWatch.ElapsedMilliseconds);
        }
    }
}
