namespace XML_Serialization;

public class ConsoleFileManager {
  public static void ChoseFileOrDirectory(string directory) {
    string currentDirectory = directory;
    while (true) {
      Console.Clear();
      Console.SetCursorPosition(Console.CursorTop, Console.CursorLeft);
      Console.WriteLine($"Current directory: {currentDirectory}\n");

      var directoryItems = new List<string>();
      directoryItems.Add("..");

      foreach (var dir in Directory.GetDirectories(currentDirectory)) {
        directoryItems.Add($"{Path.GetFileName(dir)}");
      }

      foreach (var file in Directory.GetFiles(currentDirectory)) {
        directoryItems.Add(Path.GetFileName(file));
      }

      directoryItems.Add(">>Chose current directory");
      directoryItems.Add(">>Cancel");

      string[] directoryItemsArray = directoryItems.ToArray();
      int cancelIndex = directoryItemsArray.Length - 1;
      var menu = new Menu(directoryItemsArray);

      menu.Show();
      int choice = menu.GetSelectedIndex();
      if (choice == 0) {
        currentDirectory = Directory.GetParent(currentDirectory)?.FullName ?? currentDirectory;
      }

      else if (choice == cancelIndex - 1) {
        Data.ListOfDirectories.Add(currentDirectory);
        return;
      }

      else if (choice == cancelIndex) {
        Data.CancelCheck = true;
        return;
      }
      else {
        if (Directory.Exists(Path.Combine(currentDirectory, directoryItemsArray[choice]))) {
          string targetDirectory = Path.Combine(currentDirectory, directoryItemsArray[choice]);
          currentDirectory = targetDirectory;
        }
        else {
          if (directoryItemsArray[choice].EndsWith(".txt") || directoryItemsArray[choice].EndsWith(".xml")) {
            Data.ListOfFiles.Add(Path.Combine(currentDirectory, directoryItemsArray[choice]));
            return;
          }
        }
      }
    }
  }
}