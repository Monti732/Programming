using System.ComponentModel;
using Lab2;

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
    
    

    Menu menu = new Menu(menuItems);

    while (true) {
      menu.Show();
      int choice = menu.GetSelectedIndex();
      switch (choice) {
      case 0: {
        FillInformation(msWordDocumentData, msWordData);
        MsWordDocument msWordDocument = new MsWordDocument(msWordDocumentData, 2);
        msWordDocument.ConsoleOutInformation();
        break;
      }
      case 1:
        break;
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