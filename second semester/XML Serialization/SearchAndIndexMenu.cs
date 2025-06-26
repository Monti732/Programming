namespace XML_Serialization;
    
public class SearchAndIndexMenu {
  public static void ShowMenu() {
    Console.Clear();
    var menu = new Menu(Data.SearchAndIndexItems);
    menu.Show();

    int choice = menu.GetSelectedIndex();
    var textFileIndexer = new TextFileIndexer();

    switch (choice) {
    case 0:
      Console.WriteLine("Chose a directory to index:");
      ConsoleFileManager.ChoseFileOrDirectory(Directory.GetCurrentDirectory());
      if (Data.CancelCheck) {
        Data.CancelCheck = false;
        break;
      }
      var selectedDirectory = Data.ListOfDirectories[^1];
      textFileIndexer.IndexDirectory(selectedDirectory);
      Data.IndexedDirectories.Add(selectedDirectory);
      break;

    case 1:
      if (Data.IndexedDirectories.Count == 0) {
        Console.WriteLine("Index directory first");
        Console.ReadKey();
        break;
      }
      Console.WriteLine("Chose a directory to search in:");
      var listOfIndexedDirectories = new Menu(Data.IndexedDirectories.ToArray());
      listOfIndexedDirectories.Show();
      var directoryChoice = Data.IndexedDirectories[listOfIndexedDirectories.GetSelectedIndex()];
                    
      Console.WriteLine("Enter the keyword: ");
      string keyword = Console.ReadLine();

      var results = textFileIndexer.Search(directoryChoice, keyword);

      if (results.Count == 0) {
        Console.WriteLine("No files found containing the keyword.");
      } else {
        Console.WriteLine("Files containing the keyword:");
        foreach (var item in results) {
          Console.WriteLine(item);
        }
      }

      Console.ReadKey();
      break;
    }
  }
}
