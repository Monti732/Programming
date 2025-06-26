namespace XML_Serialization;

public interface IOriginator {
  public object GetMemento();
  public void SetMemento(object memento);
}