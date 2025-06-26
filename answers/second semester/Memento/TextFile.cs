namespace XML_Serialization;

using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class TextFile {
  public string FilePath { get; set; }
  public string Content { get; set; }

  public TextFile() { }

  public TextFile(string filePath, string content) {
    FilePath = filePath;
    Content = content;
  }

  /* BinaryFormatter is obsolete(Press F), it doesn't work without comments
   public void SaveToBinary(string path)
   {
     using (FileStream fs = new FileStream(path, FileMode.Create))
     {
       BinaryFormatter formatter = new BinaryFormatter();
       formatter.Serialize(fs, this);
     }
   }

   public static TextFile LoadFromBinary(string path)
   {
     using (FileStream fs = new FileStream(path, FileMode.Open))
     {
       BinaryFormatter formatter = new BinaryFormatter();
       return (TextFile)formatter.Deserialize(fs);
     }
   }
 */
  public void SaveToXml(string path) {
    XmlSerializer serializer = new XmlSerializer(typeof(TextFile));
    using (FileStream fileStream = new FileStream(path, FileMode.Create)) {
      serializer.Serialize(fileStream, this);
    }
  }

  public static TextFile LoadFromXml(string path) {
    XmlSerializer serializer = new XmlSerializer(typeof(TextFile));
    using (FileStream fileStream = new FileStream(path, FileMode.Open)) {
      return (TextFile)serializer.Deserialize(fileStream);
    }
  }

  public static string GetFilePath(string directory, string file) {
    string newFileName = Path.GetFileName(file[..^4] + ".xml");
    string newPath = Path.Combine(directory, newFileName);
    return newPath;
  }
}