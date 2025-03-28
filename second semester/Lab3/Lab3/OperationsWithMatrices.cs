namespace Lab3;

public class OperationsWithMatrices {
  public static void SummarizeMatrix(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix left = new SquareMatrix(size, fillByYourself);
    SquareMatrix right = new SquareMatrix(size, fillByYourself);
    SquareMatrix sumMatrix = left + right;
    Console.WriteLine(sumMatrix); //it calls ToString() method automatically, wow, didn't know
  }

  public static void MultiplyMatrix(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix left = new SquareMatrix(size, fillByYourself);
    SquareMatrix right = new SquareMatrix(size, fillByYourself);
    SquareMatrix multiplyMatrix = left * right;
    Console.WriteLine(multiplyMatrix);
  }

  public static void CompareMatrix(int fillByYourself) {
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

  public static void IsZeroMatrix(int fillByYourself) {
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

  public static void FindDeterminant(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix matrix = new SquareMatrix(size, fillByYourself);
    double determimant = matrix.Determinant();
    Console.WriteLine($"{matrix}Determinant = {determimant}");
  }

  public static void ConvertToString(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix matrix = new SquareMatrix(size, fillByYourself);
    string convertedMatrix = (string)matrix;
    Console.WriteLine(convertedMatrix);
  }

  public static void FindInverseMatrix(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix matrix = new SquareMatrix(size, fillByYourself);
    SquareMatrix inverseMatrix = matrix.Inverse();
    Console.WriteLine($"Original matrix\n{matrix}Inverse matrix\n{inverseMatrix}");
  }

  public static void CloneMatrix(int fillByYourself) {
    Console.Clear();
    Console.WriteLine("Enter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    SquareMatrix matrix = new SquareMatrix(size, fillByYourself);
    SquareMatrix clone = (SquareMatrix)matrix.Clone();
    Console.WriteLine($"Original matrix\n{matrix}Clone\n{clone}");
  }
}