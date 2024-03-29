﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using OfficeOpenXml;

namespace TestDataManagement{
  public record Item(string Col1, string Col2, string Col3, string Col4, string Col5);

  public class DataManager{
    private CsvConfiguration csvConfig;
	private StreamReader sr;
	private CsvReader csvr;
	private string value= null!;
	private int noOfRecs;
	public List<Item> records= null!;

    public DataManager(string csvFile){
	  csvConfig= new CsvConfiguration(CultureInfo.CurrentCulture){
          HasHeaderRecord= false
      };

	  sr= File.OpenText(csvFile);   
 	  csvr= new CsvReader(sr, csvConfig);
	  records= csvr.GetRecords<Item>().ToList();
	  noOfRecs= records.Count();
	}

	public List<Item> getRecords(){
	  return records;
	}

    public void printCol5(){
	  for (int i=1; i<noOfRecs; i++){
	    Console.WriteLine(records.ElementAt(i).Col5);
	  }
	}

	public int addValuesInCol5(){
	  int addNo= 0;
	  for (int i=1; i<noOfRecs; i++){
	    addNo+= Int16.Parse(records.ElementAt(i).Col5);
	  }
	  return addNo; 
	}

    public void printCsv(){
	  while (csvr.Read()){
        for (int i= 0; csvr.TryGetField<string>(i, out value); i++){
		  if(value != "\n"){
            Console.Write($"{value} ");
		  }
        }
        Console.WriteLine();
      }
    }
  }

  public class TestXlsxManager{
  	private FileInfo fileInfo= null!;
  	private ExcelPackage package= null!;
  	private ExcelWorksheet worksheet;
  	public int rows;

	public TestXlsxManager(string path){
	  fileInfo= new FileInfo(path);
	  package= new ExcelPackage(fileInfo);
	  worksheet= package.Workbook.Worksheets.FirstOrDefault()!;
	}

	// Get worksheet 
	// Access rows
	public void insertTableValues(List<Item> records){

	  for(int row= 7; row <= 11; row++)
	      worksheet.Cells[row, 2].Value= records.ElementAt(row-6).Col1;

	  for(int row= 7; row <= 11; row++)
	      worksheet.Cells[row, 3].Value= records.ElementAt(row-6).Col2;

	  for(int row= 7; row <= 11; row++)
	      worksheet.Cells[row, 4].Value= records.ElementAt(row-6).Col3;

	  for(int row= 7; row <= 11; row++)
	      worksheet.Cells[row, 5].Value= records.ElementAt(row-6).Col4;

	  for(int row= 7; row <= 11; row++)
	      worksheet.Cells[row, 6].Value= records.ElementAt(row-6).Col5;

    }

	private void insertDate(){
	 // worksheet.Cells[5, 2].Value = "Test";
	}

	public void insertTotal(int total){
	  worksheet.Cells[12, 6].Value= total;
	}

	public void populateWorkSheet(int total, List<Item> records){
	  insertDate();
	  insertTableValues(records);
      insertTotal(total);	
	  saveWorkSheet();
    }

	public void saveWorkSheet(){
	  package.Save();
	}
  }

  public class App{
    static void Main(string[] args){
      Console.WriteLine("Program Start " + DateTime.Now);
      DataManager dm= new DataManager("/home/joel/db/test.csv");
	  TestXlsxManager txm= new TestXlsxManager("/home/joel/db/TestReport.xlsx");
	  txm.populateWorkSheet(dm.addValuesInCol5(), dm.getRecords());
    }
  }
} 
