using System;

namespace OutSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to OutSorter v1.0!");

            Console.WriteLine(@"Please enter a valid file path name to load (e.g. C:\Temp\data.csv):");
            var fileName = Console.ReadLine();

            Console.WriteLine("Is the first row a Row Header? (Y/N):");
            var isRowHeader = Console.ReadLine();
            
            IFileLoader loader = new CsvFileLoader();
            var records = loader.Load(fileName, isRowHeader?.ToUpper() == "Y");
            //
            IFileWriter writer = new FileWriter();
            //
            ISortManager sortManager = new SortManager(writer);
            sortManager.Sort(records);

            Console.ReadLine();
        }

        //PSEUDO

        //TASK 1:
        //Read CSV file
        //Get first two columns; FirstName & LastName
        //Concatenate first names and last names
        //Group list of names and return a count
        //Order list by count
            //And then by name
        //Output result into text file

        //TASK 2:
        //Read CSV file
        //Get thrid column; Address
        //Concatenate first names and last names
        //Group list of names and return a count
        //Order list by count
            //And then by name
        //Output result into text file
    }
}
