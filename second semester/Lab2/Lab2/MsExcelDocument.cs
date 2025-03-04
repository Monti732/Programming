namespace Lab2;

public class MsExcelDocument : BaseDocument {
  private int _numberOfLists { get; }


  public MsExcelDocument(Dictionary<DocumentInformation, object> documentData, int numberOfLists) :
    base(documentData) {
    _numberOfLists = numberOfLists;
  }
  
  public override void ConsoleOutInformation() {
    Console.Clear();
    foreach (var item in _metaData) {
      Console.WriteLine($"{item.Key}: {item.Value}\n");
    }

    Console.WriteLine($"Number of Lists: {_numberOfLists}\n");
  }
}