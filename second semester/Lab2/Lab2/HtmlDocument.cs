namespace Lab2;

public class HtmlDocument : BaseDocument {
  private string _link { get; }

  public HtmlDocument(Dictionary<DocumentInformation, object> documentData, string link) : base(documentData) {
    _link = link;
  }
  
  public override void ConsoleOutInformation() {
    Console.Clear();
    foreach (var item in _metaData) {
      Console.WriteLine($"{item.Key}: {item.Value}\n");
    }

    Console.WriteLine($"Link to document: {_link}\n");
  }
}