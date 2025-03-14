using Lab3;

class Program() {
  static void Main() {
    string[] menuItems = [
      "Summarize matrices", "Multiply matrices", "Compare matrices", "Convert to string", "Check if matrix is zero",
      "Find determinant",
      "Find inverse matrix", "Clone matrix", "Exit the program"
    ];
    string[] howFillMatrix = ["Fill Automatically", "Fill By Yourself"];
    Menu mainMenu = new Menu(menuItems);
    Menu fillMatrixMenu = new Menu(howFillMatrix);
    while (true) {
      mainMenu.Show();
      int index = mainMenu.GetSelectedIndex();
      switch (index) {
      case 0: {
        fillMatrixMenu.Show();
        if (fillMatrixMenu.GetSelectedIndex() == 1) {
          SummarizeMatrix(1);
          Console.ReadKey();
        }
        else {
          SummarizeMatrix(0);
          Console.ReadKey();
        }

        break;
      }

      case 1: {
        fillMatrixMenu.Show();
        if (fillMatrixMenu.GetSelectedIndex() == 1) {
          MultiplyMatrix(1);
          Console.ReadKey();
        }
        else {
          MultiplyMatrix(0);
          Console.ReadKey();
        }

        break;
      }

      case 2: {
        fillMatrixMenu.Show();
        if (fillMatrixMenu.GetSelectedIndex() == 1) {
          CompareMatrix(1);
          Console.ReadKey();
        }
        else {
          CompareMatrix(0);
          Console.ReadKey();
        }

        break;
      }

      case 3: {
        fillMatrixMenu.Show();
        if (fillMatrixMenu.GetSelectedIndex() == 1) {
          ConvertToString(1);
          Console.ReadKey();
        }
        else {
          ConvertToString(0);
          Console.ReadKey();
        }

        break;
      }

      case 4: {
        fillMatrixMenu.Show();
        if (fillMatrixMenu.GetSelectedIndex() == 1) {
          IsZeroMatrix(1);
          Console.ReadKey();
        }
        else {
          IsZeroMatrix(0);
          Console.ReadKey();
        }

        break;
      }
      case 5: {
        fillMatrixMenu.Show();
        if (fillMatrixMenu.GetSelectedIndex() == 1) {
          FindDeterminant(1);
          Console.ReadKey();
        }
        else {
          FindDeterminant(0);
          Console.ReadKey();
        }

        break;
      }
      case 6: {
        fillMatrixMenu.Show();
        if (fillMatrixMenu.GetSelectedIndex() == 1) {
          FindInverseMatrix(1);
          Console.ReadKey();
        }
        else {
          FindInverseMatrix(0);
          Console.ReadKey();
        }

        break;
      }
      case 7: {
        fillMatrixMenu.Show();
        if (fillMatrixMenu.GetSelectedIndex() == 1) {
          CloneMatrix(1);
          Console.ReadKey();
        }
        else {
          CloneMatrix(0);
          Console.ReadKey();
        }

        break;
      }
      case 8:
        Console.Clear();
        Console.WriteLine("Exiting program...");
        return;
      }
    }
  }

  static void SummarizeMatrix(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix left = new SquareMatrix(size, fillByYourself);
    SquareMatrix right = new SquareMatrix(size, fillByYourself);
    SquareMatrix sumMatrix = left + right;
    Console.WriteLine(sumMatrix); //it calls ToString() method automatically, wow, didn't know
  }

  static void MultiplyMatrix(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix left = new SquareMatrix(size, fillByYourself);
    SquareMatrix right = new SquareMatrix(size, fillByYourself);
    SquareMatrix multiplyMatrix = left * right;
    Console.WriteLine(multiplyMatrix);
  }

  static void CompareMatrix(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix left = new SquareMatrix(size, fillByYourself);
    SquareMatrix right = new SquareMatrix(size, fillByYourself);
    Console.WriteLine($"Matrix A\n{left}");
    Console.WriteLine($"Matrix B\n{right}");
    if (left == right) {
      Console.WriteLine("A is B");
    }
    else {
      if (left < right) {
        Console.WriteLine("A < B");
      }
      else if (left <= right) {
        Console.WriteLine("A <= B");
      }
      else if (left > right) {
        Console.WriteLine("A > B");
      }
      else {
        Console.WriteLine("A >= B");
      }
    }
  }

  static void ConvertToString(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix matrix = new SquareMatrix(size, fillByYourself);
    string convertedMatrix = (string)matrix;
    Console.WriteLine(convertedMatrix);
  }

  static void IsZeroMatrix(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix matrix = new SquareMatrix(size, fillByYourself);
    if (matrix) {
      Console.WriteLine("Matrix in not zero");
    }
    else {
      Console.WriteLine("Matrix is zero");
    }
  }

  static void FindDeterminant(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix matrix = new SquareMatrix(size, fillByYourself);
    double determimant = matrix.Determinant();
    Console.WriteLine($"{matrix}Determinant = {determimant}");
  }

  static void FindInverseMatrix(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix matrix = new SquareMatrix(size, fillByYourself);
    SquareMatrix inverseMatrix = matrix.Inverse();
    Console.WriteLine($"Original matrix\n{matrix}Inverse matrix\n{inverseMatrix}");
  }

  static void CloneMatrix(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix matrix = new SquareMatrix(size, fillByYourself);
    SquareMatrix clone = (SquareMatrix)matrix.Clone();
    Console.WriteLine($"Original matrix\n{matrix}Clone\n{clone}");
  }
}