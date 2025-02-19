namespace Lab2;

public class TxtDocument : BaseDocument {
  private int _numberOfCharacters { get; }
  
  private static TxtDocument _instance;
  
  private TxtDocument(Dictionary<DocumentInformation, object> documentData, int numberOfCharacters) : base(documentData) {
    _numberOfCharacters = numberOfCharacters;
  }

  public static TxtDocument GetInstance(Dictionary<DocumentInformation, object> documentData, int numberOfCharacters) {
    if (_instance == null) {
      _instance = new TxtDocument(documentData, numberOfCharacters);
    }
    return _instance;
  }
   
  public override void ConsoleOutInformation() {
    Console.Clear();
    foreach (var item in _metaData) {
      Console.WriteLine($"{item.Key}: {item.Value}\n");
    }

    Console.WriteLine($"Number of characters: {_numberOfCharacters}\n");
  }
}