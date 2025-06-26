namespace Delegates_and_Events;

public class SingleMatrixOperationHandler : MatrixOperationHandler {
  private delegate SquareMatrix DiagonalizeMatrixDelegate(SquareMatrix matrix);

  public override void HandleOperation(int operationChoice, ref SquareMatrix matrixA, ref SquareMatrix matrixB) {
    //seems like this break the chain of responsibility pattern logic,
    //but I don't know how to do it another way
    if (operationChoice > 7 && _nextHandler != null) { 
      _nextHandler.HandleOperation(operationChoice, ref matrixA, ref matrixB); 
      return;
    }
    
    Console.Clear();

    var matrixChoiceMenu = new Menu(Data.MatrixList); 
    //very stupid but compiler gets angry without(Local variable 'matrixChoice' might not be initialized before accessing)
    int matrixChoice = -1; 
    matrixChoiceMenu.OnItemSelected += choice => { matrixChoice = choice; };
    if (operationChoice != 7) matrixChoiceMenu.Show();
    
    switch (operationChoice) {
    case 2:
      SquareMatrix transposed = (matrixChoice == 0) ? matrixA.Transpose() : matrixB.Transpose();
      Console.WriteLine($"Transposed {Data.MatrixList[matrixChoice]}\n");
      Console.WriteLine(transposed);
      Console.ReadKey();
      break;
    case 3:
      double trace = (matrixChoice == 0) ? matrixA.FindTrace() : matrixB.FindTrace();
      Console.WriteLine($"{Data.MatrixList[matrixChoice]} Trace: {trace}");
      Console.ReadKey();
      break;
    case 4:
      try {
        double det = (matrixChoice == 0) ? matrixA.Determinant() : matrixB.Determinant();
        Console.WriteLine($"{Data.MatrixList[matrixChoice]} Determinant: {det}");
      }
      catch (MatrixException ex) {
        Console.WriteLine($"Error: {ex.Message}");
      }

      Console.ReadKey();
      break;
    case 5:
      try {
        SquareMatrix inverse = (matrixChoice == 0) ? matrixA.Inverse() : matrixB.Inverse();
        Console.WriteLine($"Inverse {Data.MatrixList[matrixChoice]}:\n");
        Console.WriteLine(inverse);
      }
      catch (MatrixException ex) {
        Console.WriteLine($"Error: {ex.Message}");
      }

      Console.ReadKey();
      break;
    case 6:
      DiagonalizeMatrixDelegate diagonalizeMatrix = delegate(SquareMatrix matrix) {
        SquareMatrix diagonal = (SquareMatrix)matrix.Clone();
        for (int row = 0; row < diagonal.Size; ++row) {
          for (int col = 0; col < diagonal.Size; ++col) {
            if (row != col) {
              diagonal.Matrix[row, col] = 0;
            }
          }
        }

        return diagonal;
      };

      SquareMatrix diagonalMatrix = (matrixChoice == 0) ? diagonalizeMatrix(matrixA) : diagonalizeMatrix(matrixB);
      Console.WriteLine($"Diagonal Form of {Data.MatrixList[matrixChoice]}:\n");
      Console.WriteLine(diagonalMatrix);
      Console.ReadKey();
      break;
    case 7:
      // .NET 9.0 is something
      // switch statement takes the result of CompareTo
      // and on base of result(true, false, other)
      // save the concrete string to variable. Crazy.
      string comparison = matrixA.CompareTo(matrixB) switch { 
        > 0 => "Matrix A > Matrix B", 
        < 0 => "Matrix A < Matrix B", 
        _ => "Matrix A = Matrix B" 
      };
      Console.WriteLine(comparison);
      Console.ReadKey();
      break;
    default:
      if (_nextHandler != null)
        _nextHandler.HandleOperation(operationChoice, ref matrixA, ref matrixB);
      break;
    }
  }
}