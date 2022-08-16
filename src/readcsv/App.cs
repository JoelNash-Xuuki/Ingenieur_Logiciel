using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

class App{

  void printCsv(){
    var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
    {
        HasHeaderRecord = false
    };

    using var streamReader = File.OpenText("test.csv");
    using var csvReader = new CsvReader(streamReader, csvConfig);
    string value;

    while (csvReader.Read()){
      for (int i = 0; csvReader.TryGetField<string>(i, out value); i++){
       Console.Write($"{value} ");
      }
     Console.WriteLine();
   }
  }

  static void Main(string[] args){
    Console.WriteLine("Program Start " + DateTime.Now);
  }
}
  
 

 
