namespace Generics_and_lambda_expressions;

public class TreeManager {
  public void TreeLoop<T>(Func<string, T> parser) where T : IComparable<T> {
    var tree = new BinaryTree<T>();
    var menuManager = new MenuManager<T>(tree, parser);
    var menu = new Menu(Data.MenuItems);
    menu.OnItemSelected += choice => menuManager.MenuChoice(choice);
    while (true) {
      Console.Clear();
      menu.Show();
    }
  }

  public void ChangeTreeType() {
    var binaryTreeTypeChoiceMenu = new Menu(Data.BinaryTreeTypes);
    binaryTreeTypeChoiceMenu.OnItemSelected += choice => {
      switch (choice) {
      case 0: IntTreeLoop(); break;
      case 1: FloatTreeLoop(); break;
      case 2: StringTreeLoop(); break;
      }
    };
    binaryTreeTypeChoiceMenu.Show();
  }

  private void IntTreeLoop() => TreeLoop(int.Parse);
  
  private void FloatTreeLoop() => TreeLoop(float.Parse);

  private void StringTreeLoop() => TreeLoop(input => input);
}