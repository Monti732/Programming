namespace Lab2;

public class HtmlDocument : BaseDocument {
  private string _link { get; }

  private static HtmlDocument _instance;

  private HtmlDocument(Dictionary<DocumentInformation, object> documentData, string link) : base(documentData) {
    _link = link;
  }

  public static HtmlDocument GetInstance(Dictionary<DocumentInformation, object> documentData, string link) {
    if (_instance == null) {
      _instance = new HtmlDocument(documentData, link);
    }

    return _instance;
  }

  public override void ConsoleOutInformation() {
    Console.Clear();
    foreach (var item in _metaData) {
      Console.WriteLine($"{item.Key}: {item.Value}\n");
    }

    Console.WriteLine($"Link to document: {_link}\n");
  }
}