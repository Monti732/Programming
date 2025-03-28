namespace Lab3;

public class MainMenu : Menu {
  public MainMenu(string[] items) : base(items) { }

  public override void Show() {
    MenuItems fillMatrixMenu = new MenuItems();
    FillMatrixMenu matrixMenu = new FillMatrixMenu(fillMatrixMenu.FillMatrixItems);
    while (true) {
      Console.Clear();
      Console.WriteLine("ULTRA MEGA CALCULATOR\n");

      base.Show();
      int index = GetSelectedIndex();
      switch (index) {
      case 0: {
        matrixMenu.Show();
        int matrixIndex = matrixMenu.GetSelectedIndex();
        if (matrixIndex == 1) {
          OperationsWithMatrices.SummarizeMatrix(1);
          Console.ReadKey();
        }
        else {
          OperationsWithMatrices.SummarizeMatrix(0);
          Console.ReadKey();
        }

        break;
      }
      case 1: {
        matrixMenu.Show();
        int matrixIndex = matrixMenu.GetSelectedIndex();
        if (matrixIndex == 1) {
          OperationsWithMatrices.MultiplyMatrix(1);
          Console.ReadKey();
        }
        else {
          OperationsWithMatrices.MultiplyMatrix(0);
          Console.ReadKey();
        }

        break;
      }
      case 2: {
        matrixMenu.Show();
        int matrixIndex = matrixMenu.GetSelectedIndex();
        if (matrixIndex == 1) {
          OperationsWithMatrices.CompareMatrix(1);
          Console.ReadKey();
        }
        else {
          OperationsWithMatrices.CompareMatrix(0);
          Console.ReadKey();
        }

        break;
      }

      case 3: {
        matrixMenu.Show();
        int matrixIndex = matrixMenu.GetSelectedIndex();
        if (matrixIndex == 1) {
          OperationsWithMatrices.ConvertToString(1);
          Console.ReadKey();
        }
        else {
          OperationsWithMatrices.ConvertToString(0);
          Console.ReadKey();
        }

        break;
      }

      case 4: {
        matrixMenu.Show();
        int matrixIndex = matrixMenu.GetSelectedIndex();
        if (matrixIndex == 1) {
          OperationsWithMatrices.IsZeroMatrix(1);
          Console.ReadKey();
        }
        else {
          OperationsWithMatrices.IsZeroMatrix(0);
          Console.ReadKey();
        }

        break;
      }
      case 5: {
        matrixMenu.Show();
        int matrixIndex = matrixMenu.GetSelectedIndex();
        if (matrixIndex == 1) {
          OperationsWithMatrices.FindDeterminant(1);
          Console.ReadKey();
        }
        else {
          OperationsWithMatrices.FindDeterminant(0);
          Console.ReadKey();
        }

        break;
      }
      case 6: {
        matrixMenu.Show();
        int matrixIndex = matrixMenu.GetSelectedIndex();
        if (matrixIndex == 1) {
          OperationsWithMatrices.FindInverseMatrix(1);
          Console.ReadKey();
        }
        else {
          OperationsWithMatrices.FindInverseMatrix(0);
          Console.ReadKey();
        }

        break;
      }
      case 7: {
        matrixMenu.Show();
        int matrixIndex = matrixMenu.GetSelectedIndex();
        if (matrixIndex == 1) {
          OperationsWithMatrices.CloneMatrix(1);
          Console.ReadKey();
        }
        else {
          OperationsWithMatrices.CloneMatrix(0);
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