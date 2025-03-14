using Lab2;
using Microsoft.Office.Interop.Word;

class Program() {
  static void Main() {
    string[] menuItems = {
      "MS Word",
      "PDF",
      "MS Excel",
      "TXT",
      "HTML",
      "Exit program"
    };

    Data msWordData = new Data("text.docs", "User", "C:\\Users\\User\\Desktop\\text.docs", "C#", "OOP, Programming");
    Dictionary<DocumentInformation, object> msWordDocumentData = new Dictionary<DocumentInformation, object>();

    Data pdfData = new Data("Patterny_proektirovanija.pdf", "NotAUser",
      "C:\\Users\\NotAUser\\media\\Patterny_proektirovanija.pdf", "C#", "OOP, Programming");
    Dictionary<DocumentInformation, object> pdfDocumentData = new Dictionary<DocumentInformation, object>();

    Data msExcelData = new Data("Financial_Report.xlsx", "John Doe",
      "C:/Documents/Reports/Financial_Report.xlsx", "Financial Analysis", "finance, report, Excel, budget, data");
    Dictionary<DocumentInformation, object> msExcelDocumentData = new Dictionary<DocumentInformation, object>();

    Data txtData = new Data("Notes.txt", "Alice Johnson", "C:/Users/Alice/Documents/Notes.txt", "Personal Notes",
      "notes, text, reminders, to-do list");
    Dictionary<DocumentInformation, object> txtDocumentData = new Dictionary<DocumentInformation, object>();

    Data htmlData = new Data("index.html", "Michael Smith", "C:/Projects/Website/index.html", "Website Homepage",
      "HTML, CSS, JavaScript, web, homepage");
    Dictionary<DocumentInformation, object> htmlDocumentData = new Dictionary<DocumentInformation, object>();

    Menu menu = new Menu(menuItems);

    while (true) {
      menu.Show();
      int choice = menu.GetSelectedIndex();
      switch (choice) {
      case 0: {
        FillInformation(msWordDocumentData, msWordData);
        MsWordDocument msWordDocument = MsWordDocument.GetInstance(msWordDocumentData, 3);
        msWordDocument.ConsoleOutInformation();
        break;
      }
      case 1: {
        FillInformation(pdfDocumentData, pdfData);
        PDFDocument pdfDocument = PDFDocument.GetInstance(pdfDocumentData, true);
        pdfDocument.ConsoleOutInformation();
        break;
      }
      case 2: {
        FillInformation(msExcelDocumentData, msExcelData);
        MsExcelDocument msExcelDocument = MsExcelDocument.GetInstance(msExcelDocumentData, 10);
        msExcelDocument.ConsoleOutInformation();
        break;
      }
      case 3: {
        FillInformation(txtDocumentData, txtData);
        TxtDocument txtDocument = TxtDocument.GetInstance(txtDocumentData, 3324);
        txtDocument.ConsoleOutInformation();
        break;
      }
      case 4: {
        FillInformation(htmlDocumentData, htmlData);
        HtmlDocument htmlDocument = HtmlDocument.GetInstance(htmlDocumentData, "http://127.0.0.1:5500/lab2/index.html");
        htmlDocument.ConsoleOutInformation();
        break;
      }
      }

      Console.WriteLine("To continue press any key...");
      Console.ReadKey(true);
      Console.Clear();
    }
  }

  static void FillInformation(Dictionary<DocumentInformation, object> docInfo, Data information) {
    docInfo[DocumentInformation.Name] = information.Name;
    docInfo[DocumentInformation.Author] = information.Author;
    docInfo[DocumentInformation.Path] = information.Path;
    docInfo[DocumentInformation.Topic] = information.Topic;
    docInfo[DocumentInformation.Keywords] = information.Keywords;
  }
}