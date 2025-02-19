namespace Lab2;

public abstract class BaseDocument {
  protected Dictionary<DocumentInformation, object> _metaData { get; } =
    new Dictionary<DocumentInformation, object>();

  protected BaseDocument(Dictionary<DocumentInformation, object> metaData) {
    _metaData = metaData;
  }

  public virtual void ConsoleOutInformation() {
    foreach (var item in _metaData) {
      Console.WriteLine($"{item.Key}: {item.Value}");
    }
  }
} 