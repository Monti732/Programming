namespace Generics_and_lambda_expressions;

public class MenuManager<T> where T : IComparable<T> {
  private BinaryTree<T> _tree;
  private Func<string, T> _parser;

  public MenuManager(BinaryTree<T> tree, Func<string, T> parser) {
    _tree = tree;
    _parser = parser;
  }

  public void MenuChoice(int choice) {
    switch (choice) {
    case 0:
      AddNode();
      break;
    case 1:
      RemoveNode();
      break;
    case 2:
      Contains();
      break;
    case 3:
      TraversalInOrder();
      break;
    case 4:
      ReverseTraversal();
      break;
    case 5:
      ChangeTreeType();
      break;
    case 6:
      Exit();
      break;
    }
  }

  private void AddNode() {
    Console.WriteLine("Enter value: ");
    var input = Console.ReadLine();
    try {
      var parsedValue = _parser(input);
      _tree.Add(parsedValue);
    }
    catch (Exception ex) {
      Console.WriteLine($"Error parsing value: {ex.Message}");
      Console.ReadKey();
    }
  }

  private void RemoveNode() {
    Console.WriteLine("Enter value: ");
    var input = Console.ReadLine();
    T parsedValue;
    try {
      parsedValue = _parser(input);
    }
    catch (Exception ex) {
      Console.WriteLine($"Error parsing value: {ex.Message}");
      Console.ReadKey();
      return;
    }

    if (!_tree.Contains(parsedValue)) return;
    _tree.Remove(parsedValue);
  }

  private void Contains() {
    Console.WriteLine("Enter value: ");
    var input = Console.ReadLine();
    T parsedValue;
    try {
      parsedValue = _parser(input);
    }
    catch (Exception ex) {
      Console.WriteLine($"Error parsing value: {ex.Message}");
      Console.ReadKey();
      return;
    }

    int counter = 0;
    foreach (T value in _tree.InOrderTraversal()) {
      if (EqualityComparer<T>.Default.Equals(value, parsedValue)) {
        counter++;
      }
    }
    
    Console.WriteLine($"Value {parsedValue} is contained {counter} times");
    Console.ReadKey();
  }

  private void TraversalInOrder() {
    foreach (var item in _tree.InOrderTraversal()) {
      Console.Write($"{item} ");
    }

    Console.ReadKey();
  }

  private void ReverseTraversal() {
    foreach (var item in _tree.InOrderTraversal().Reverse()) {
      Console.Write($"{item} ");
    }

    Console.ReadKey();
  }

  private void ChangeTreeType() {
    var treeManager = new TreeManager();
    treeManager.ChangeTreeType();
  }

  private void Exit() => Environment.Exit(0);
}