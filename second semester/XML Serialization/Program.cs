namespace XML_Serialization;

class Program {
  static void Main() {
    var mainMenu = new Menu(Data.MainMenuItems);
    while (true) {
      Console.Clear();
      mainMenu.Show();
      int choice = mainMenu.GetSelectedIndex();
      switch (choice) {
      case 0:
        ConsoleFileManager.ChoseFileOrDirectory(Directory.GetCurrentDirectory());
        if (Data.CancelCheck) {
          Data.CancelCheck = false;
          break;
        }
        var editor = new TextEditor(Data.ListOfFiles[^1]);
        editor.Run();
        break;
      case 1:
        SerializationMenu.ShowMenu();
        break;
      case 2:
        SearchAndIndexMenu.ShowMenu();
        break;
      case 3:
        return;
      }
    }
  }
}

  