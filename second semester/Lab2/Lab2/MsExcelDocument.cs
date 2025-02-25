namespace Lab2;

public class MsExcelDocument : BaseDocument {
  private int _numberOfLists { get; }

  private static MsExcelDocument _instance;

  private MsExcelDocument(Dictionary<DocumentInformation, object> documentData, int numberOfLists) :
    base(documentData) {
    _numberOfLists = numberOfLists;
  }

  public static MsExcelDocument GetInstance(Dictionary<DocumentInformation, object> documentData, int numberOfLists) {
    if (_instance == null) {
      _instance = new MsExcelDocument(documentData, numberOfLists);
    }

    return _instance;
  }

  public override void ConsoleOutInformation() {
    Console.Clear();
    foreach (var item in _metaData) {
      Console.WriteLine($"{item.Key}: {item.Value}\n");
    }

    Console.WriteLine($"Number of Lists: {_numberOfLists}\n");
  }
}