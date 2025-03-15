namespace Lab3;

public class MainMenu : Menu {
  private string[] _menuItems;
  private int _selectedIndex;

  public MainMenu(string[] items) : base(items) {
    _menuItems = items;
  }

  public override void Show() {
    MenuItems fillMatrixMenu = new MenuItems();
    FillMatrixMenu matrixMenu = new FillMatrixMenu(fillMatrixMenu.FillMatrixItems);
    int index = _selectedIndex;
    while (true) {
      Console.Clear();
      Console.WriteLine("ULTRA MEGA CALCULATOR\n");
      base.Show();
      switch (index) {
      case 0: {
        matrixMenu.Show();
        if (matrixMenu.GetSelectedIndex() == 1) {
          // SummarizeMatrix(1);
          Console.ReadKey();
        }
        else {
          //SummarizeMatrix(0);
          Console.ReadKey();
        }

        break;
      }
      case 1: {
        matrixMenu.Show();
        if (matrixMenu.GetSelectedIndex() == 1) {
          //MultiplyMatrix(1);
          Console.ReadKey();
        }
        else {
          //MultiplyMatrix(0);
          Console.ReadKey();
        }

        break;
      }

      case 2: {
        matrixMenu.Show();
        if (matrixMenu.GetSelectedIndex() == 1) {
          // CompareMatrix(1);
          Console.ReadKey();
        }
        else {
          //  CompareMatrix(0);
          Console.ReadKey();
        }

        break;
      }

      case 3: {
        matrixMenu.Show();
        if (matrixMenu.GetSelectedIndex() == 1) {
          //ConvertToString(1);
          Console.ReadKey();
        }
        else {
          // ConvertToString(0);
          Console.ReadKey();
        }

        break;
      }

      case 4: {
        matrixMenu.Show();
        if (matrixMenu.GetSelectedIndex() == 1) {
          //  IsZeroMatrix(1);
          Console.ReadKey();
        }
        else {
          //  IsZeroMatrix(0);
          Console.ReadKey();
        }

        break;
      }
      case 5: {
        matrixMenu.Show();
        if (matrixMenu.GetSelectedIndex() == 1) {
          //  FindDeterminant(1);
          Console.ReadKey();
        }
        else {
          // FindDeterminant(0);
          Console.ReadKey();
        }

        break;
      }
      case 6: {
        matrixMenu.Show();
        if (matrixMenu.GetSelectedIndex() == 1) {
          //  FindInverseMatrix(1);
          Console.ReadKey();
        }
        else {
          //  FindInverseMatrix(0);
          Console.ReadKey();
        }

        break;
      }
      case 7: {
        matrixMenu.Show();
        if (matrixMenu.GetSelectedIndex() == 1) {
          //  CloneMatrix(1);
          Console.ReadKey();
        }
        else {
          //  CloneMatrix(0);
          Console.ReadKey();
        }

        break;
      }
      case 8:
        Console.Clear();
        Console.WriteLine("Exiting program...");
        System.Environment.Exit(0);
        break;
      }
    }
  }
}