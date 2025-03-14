namespace Lab2;

public class MsWordDocument : BaseDocument {
  private int _numberOfPages { get; }

  private static MsWordDocument _instance;

  private MsWordDocument(Dictionary<DocumentInformation, object> documentData, int numberOfPages) : base(documentData) {
    _numberOfPages = numberOfPages;
  }

  public static MsWordDocument GetInstance(Dictionary<DocumentInformation, object> documentData, int numberOfPages) {
    if (_instance == null) {
      _instance = new MsWordDocument(documentData, numberOfPages);
    }

    return _instance;
  }

  public override void ConsoleOutInformation() {
    Console.Clear();
    foreach (var item in _metaData) {
      Console.WriteLine($"{item.Key}: {item.Value}\n");
    }

    Console.WriteLine($"Number of pages: {_numberOfPages}\n");
  }
}