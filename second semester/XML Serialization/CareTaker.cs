namespace XML_Serialization;

public class CareTaker {
  private Stack<object> _history = new Stack<object>();

  public void SaveState(IOriginator originator) {
    _history.Push(originator.GetMemento());
  }

  public void RestoreState(IOriginator originator) {
    if (_history.Count >= 1) {
      originator.SetMemento(_history.Pop());
    }
  }
}