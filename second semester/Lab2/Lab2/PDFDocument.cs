namespace Lab2;

public class PDFDocument : BaseDocument {
  private bool _doesPasswordIsNedeed { get; }
  
  public PDFDocument(Dictionary<DocumentInformation, object> documentData, bool doesPasswordIsNedeed) :
    base(documentData) {
    _doesPasswordIsNedeed = doesPasswordIsNedeed;
  }
  
  public override void ConsoleOutInformation() {
    Console.Clear();
    foreach (var item in _metaData) {
      Console.WriteLine($"{item.Key}: {item.Value}\n");
    }

    Console.WriteLine($"Does password is nedeed: {_doesPasswordIsNedeed}\n");
  }
}