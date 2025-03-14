namespace Lab2;

public class PDFDocument : BaseDocument {
  private bool _doesPasswordIsNedeed { get; }

  private static PDFDocument _instance;

  private PDFDocument(Dictionary<DocumentInformation, object> documentData, bool doesPasswordIsNedeed) :
    base(documentData) {
    _doesPasswordIsNedeed = doesPasswordIsNedeed;
  }

  public static PDFDocument GetInstance(Dictionary<DocumentInformation, object> documentData,
    bool doesPasswordIsNedeed) {
    if (_instance == null) {
      _instance = new PDFDocument(documentData, doesPasswordIsNedeed);
    }

    return _instance;
  }

  public override void ConsoleOutInformation() {
    Console.Clear();
    foreach (var item in _metaData) {
      Console.WriteLine($"{item.Key}: {item.Value}\n");
    }

    Console.WriteLine($"Does password is nedeed: {_doesPasswordIsNedeed}\n");
  }
}