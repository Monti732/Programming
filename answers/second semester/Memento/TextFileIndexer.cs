namespace XML_Serialization;
public class TextFileIndexer {
  private static Dictionary<string, Dictionary<string, List<string>>> directoryIndexes =
    new Dictionary<string, Dictionary<string, List<string>>>();

  public void IndexDirectory(string directory) {
    if (!directoryIndexes.ContainsKey(directory)) {
      directoryIndexes[directory] = new Dictionary<string, List<string>>();
    }

    var index = directoryIndexes[directory];

    foreach (var file in Directory.GetFiles(directory, "*.txt")) {
      string content = File.ReadAllText(file);
      foreach (var word in content.Split(' ', StringSplitOptions.RemoveEmptyEntries)) {
        string keyword = word.ToLower();
        if (!index.ContainsKey(keyword)) {
          index[keyword] = new List<string>();
        }

        if (!index[keyword].Contains(file)) {
          index[keyword].Add(file);
        }
      }
    }
  }

  public List<string> Search(string directory, string keyword) {
    keyword = keyword.ToLower();

    if (directoryIndexes.ContainsKey(directory) && directoryIndexes[directory].ContainsKey(keyword)) {
      return directoryIndexes[directory][keyword];
    }

    return new List<string>();
  }
}