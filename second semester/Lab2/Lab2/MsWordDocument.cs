namespace Lab2;

public class MsWordDocument : BaseDocument {
  private int _numberOfPages { get; }
  
  public MsWordDocument(Dictionary<DocumentInformation, object> documentData, int numberOfPages) : base(documentData) {
    _numberOfPages = numberOfPages;
  }
  
  public override void ConsoleOutInformation() {
    Console.Clear();
    foreach (var item in _metaData) {
      Console.WriteLine($"{item.Key}: {item.Value}\n");
    }

    Console.WriteLine($"Number of pages: {_numberOfPages}\n");
  }
}