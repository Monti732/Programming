namespace XML_Serialization;

public static class Data {
  public static string[] MainMenuItems =
    ["Work with txt", "Serialization", "Search and index files", "Exit"];

  public static string[] SerializationItems =
    ["Save to XML", "Load from XML", "Save to binary(dont work)", "Load from binary(dont work)"];

  public static string[] SearchAndIndexItems = ["Index directory", "Search in file by keywords"];
  public static bool CancelCheck = false;

  public static List<string> IndexedDirectories { get; set; } = new List<string>();
  public static List<string> ListOfFiles { get; set; } = new List<string>();
  public static List<string> ListOfDirectories { get; set; } = new List<string>();
}