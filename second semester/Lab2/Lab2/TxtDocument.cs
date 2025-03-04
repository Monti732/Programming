namespace Lab2;

public class TxtDocument : BaseDocument {
  private int _numberOfCharacters { get; }
  
  public TxtDocument(Dictionary<DocumentInformation, object> documentData, int numberOfCharacters) :
    base(documentData) {
    _numberOfCharacters = numberOfCharacters;
  }
  
  public override void ConsoleOutInformation() {
    Console.Clear();
    foreach (var item in _metaData) {
      Console.WriteLine($"{item.Key}: {item.Value}\n");
    }

    Console.WriteLine($"Number of characters: {_numberOfCharacters}\n");
  }
}