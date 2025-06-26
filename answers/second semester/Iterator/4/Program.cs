public interface IIterator<T> {
  bool HasNext();
  T Next();
}

public interface ICustomCollection<T> {
  IIterator<T> CreateIterator();
}

public class CustomCollection<T> : ICustomCollection<T> {
  private List<T> _items = new List<T>();

  public void Add(T item) {
    _items.Add(item);
  }

  public T this[int index] => _items[index];

  public int Count => _items.Count;

  public IIterator<T> CreateIterator() {
    return new CustomIterator<T>(this);
  }
}

public class CustomIterator<T> : IIterator<T> {
  private CustomCollection<T> _collection;
  private int _position = 0;

  public CustomIterator(CustomCollection<T> collection) {
    _collection = collection;
  }

  public bool HasNext() {
    return _position < _collection.Count;
  }

  public T Next() {
    return _collection[_position++];
  }
}

class Program {
  static void Main() {
    var collection = new CustomCollection<string>();
    collection.Add("Apple");
    collection.Add("Banana");
    collection.Add("Cherry");

    var iterator = collection.CreateIterator();

    while (iterator.HasNext()) {
      Console.WriteLine(iterator.Next());
    }
  }
}