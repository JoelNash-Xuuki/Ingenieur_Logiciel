using OfficeOpenXml;

namespace XlsxManager{

  public class XlsxEditor{
    public XlsxEditor(){}
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
	
	public void getSheetRowNo(){
	  this.rows= worksheet.Dimension.Rows;
	}

    public void saveWorkSheet(){
	  package.Save();
	}

	private void insertDate(){
	  worksheet.Cells[5, 2].Value = "Test";
	}

	private void insertTotal(){
	  worksheet.Cells[12, 6].Value = "Test";
	}

	private void insertTableValues(){
	  for(int col= 2; col <=6; col++){
        for(int row= 7; row <= 11; row++){
            worksheet.Cells[row, col].Value = "Test";
	    }
	  }
	}

    public void populateWorkSheet(){
	  insertDate();
	  insertTableValues();
      insertTotal();	
    }
  }

  public class App{
    static void Main(string[] args){
      Console.WriteLine("Program Start " + DateTime.Now);
	  TestXlsxManager txm= new TestXlsxManager("/home/joel/db/TestReport.xlsx");
	  txm.populateWorkSheet();
	  txm.saveWorkSheet();
    }
  }
}
