using System.Collections;

namespace Generics_and_lambda_expressions;

public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T> {
  public class Node {
    public T Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node Parent { get; set; }

    public Node(T value) {
      Value = value;
      Left = null;
      Right = null;
      Parent = null;
    }
  }

  private Node _root;

  public BinaryTree() {
    _root = null;
  }

  public void Add(T value) {
    if (_root == null) {
      _root = new Node(value);
      return;
    }

    AddNode(_root, value);
  }

  private void AddNode(Node current, T value) {
    if (value.CompareTo(current.Value) < 0) {
      if (current.Left == null) {
        current.Left = new Node(value);
        current.Left.Parent = current;
      }
      else {
        AddNode(current.Left, value);
      }
    }
    else {
      if (current.Right == null) {
        current.Right = new Node(value);
        current.Right.Parent = current;
      }
      else {
        AddNode(current.Right, value);
      }
    }
  }

  public bool Contains(T value) => FindNode(_root, value) != null;

  private Node FindNode(Node current, T value) {
    if (current == null) {
      return null;
    }

    int compareResult = value.CompareTo(current.Value);

    if (compareResult == 0) {
      return current;
    }
    else if (compareResult < 0) {
      return FindNode(current.Left, value);
    }
    else {
      return FindNode(current.Right, value);
    }
  }

  public void Remove(T value) => _root = RemoveNode(_root, value);
  
  private Node RemoveNode(Node current, T value) {
    if (current == null) {
      return null;
    }
    
    int compareResult = value.CompareTo(current.Value);

    if (compareResult < 0) {
      current.Left = RemoveNode(current.Left, value);
      if (current.Left != null) {
        current.Left.Parent = null;
      }
    }
    else if (compareResult > 0) {
      current.Right = RemoveNode(current.Right, value);
      if (current.Right != null) {
        current.Right.Parent = null;
      }
    }
    else {
      if (current.Left == null) {
        return current.Right;
      }
      else if (current.Right == null) {
        return current.Left;
      }

      current.Value = MinValue(current.Right);

      current.Right = RemoveNode(current.Right, current.Value);
      if (current.Right != null) {
        current.Right.Parent = current;
      }
    }

    return current;
  }

  private T MinValue(Node node) {
    T minValue = node.Value;
    while (node.Left != null) {
      minValue = node.Left.Value;
      node = node.Left;
    }

    return minValue;
  }

  public class BinaryTreeIterator : IEnumerator<T> {
    private Node _root;
    private Node _current;
    private bool _isStarted;

    public BinaryTreeIterator(Node root) {
      this._root = root;
      Reset();
    }

    public T Current => _current != null ? _current.Value : default;

    object IEnumerator.Current => Current;

    public void Dispose() { }

    public static BinaryTreeIterator operator ++(BinaryTreeIterator current) {
      current.MoveNext();
      return current;
    }

    public static BinaryTreeIterator operator --(BinaryTreeIterator current) {
      current.MovePrevious();
      return current;
    }
    
    public bool MoveNext() {
      if (_root == null) {
        return false;
      }

      if (!_isStarted) {
        _current = _root;
        while (_current.Left != null) _current = _current.Left;
        _isStarted = true;
        return true;
      }

      _current = Next(_current);
      return _current != null;
    }

    public bool MovePrevious() {
      if (_root == null) {
        return false;
      }

      if (!_isStarted) {
        _current = _root;
        while (_current.Right != null) _current = _current.Right;
        _isStarted = true;
        return true;
      }

      _current = Previous(_current);
      return _current != null;
    }

    public Node Next(Node xNode) {
      if (xNode == null) {
        return null;
      }

      if (xNode.Right != null) {
        Node yNode = xNode.Right;
        while (yNode.Left != null) yNode = yNode.Left;
        return yNode;
      }

      Node parent = xNode.Parent;
      while (parent != null && xNode == parent.Right) {
        xNode = parent;
        parent = parent.Parent;
      }

      return parent;
    }

    public Node Previous(Node xNode) {
      if (xNode == null)
        return null;

      if (xNode.Left != null) {
        Node yNode = xNode.Left;
        while (yNode.Right != null) yNode = yNode.Right;
        return yNode;
      }

      Node parent = xNode.Parent;
      while (parent != null && xNode == parent.Left) {
        xNode = parent;
        parent = parent.Parent;
      }

      return parent;
    }

    public void Reset() {
      _current = null;
      _isStarted = false;
    }
  }

  public IEnumerator<T> GetEnumerator() => new BinaryTreeIterator(_root);

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

  public IEnumerable<T> InOrderTraversal() {
    List<T> result = new List<T>();

    Action<Node> traverseInOrder = null;
    traverseInOrder = (node) => {
      if (node == null) return;

      traverseInOrder(node.Left);

      result.Add(node.Value);

      traverseInOrder(node.Right);
    };

    traverseInOrder(_root);

    return result;
  }
}