namespace XML_Serialization;

public class SerializationMenu {
  public static void ShowMenu() {
    Console.Clear();
    var menu = new Menu(Data.SerializationItems);
    menu.Show();

    int choice = menu.GetSelectedIndex();

    switch (choice) {
    case 0:
      Console.WriteLine("Chose a source file");
      Console.ReadKey(true);

      ConsoleFileManager.ChoseFileOrDirectory(Directory.GetCurrentDirectory());
      if (Data.CancelCheck) {
        Data.CancelCheck = false;
        break;
      }
      var textFile = new TextFile(Data.ListOfFiles[^1], File.ReadAllText(Data.ListOfFiles[^1]));

      Console.Clear();
      Console.WriteLine("Chose a directory to save the XML file");
      Console.ReadKey();

      ConsoleFileManager.ChoseFileOrDirectory(Directory.GetCurrentDirectory());
      textFile.SaveToXml(TextFile.GetFilePath(Data.ListOfDirectories[^1], Data.ListOfFiles[^1]));
      break;
    case 1:
      Console.WriteLine("Chose a source file to load from");
      Console.ReadKey();

      ConsoleFileManager.ChoseFileOrDirectory(Directory.GetCurrentDirectory());
      if (Data.CancelCheck) {
        Data.CancelCheck = false;
        break;
      }
      Console.Clear();
      TextFile xmlFile = TextFile.LoadFromXml(Data.ListOfFiles[^1]);
      Console.WriteLine(xmlFile.Content);
      Console.ReadKey();
      break;
    }
  }
}