namespace Lab2;

public class DocumentManager {
  private DocumentManager() {}
  public void ConsoleOutInformation(BaseDocument document) {
    document.ConsoleOutInformation();
  }
  private static DocumentManager _instance;
  public static DocumentManager GetInstance() {
    if (_instance == null) {
      _instance = new DocumentManager();
    }

    return _instance;
  }
}