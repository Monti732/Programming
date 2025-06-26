namespace Delegates_and_Events;

public class BasicMatrixOperationHandler : MatrixOperationHandler {
  public override void HandleOperation(int operationChoice, ref SquareMatrix matrixA, ref SquareMatrix matrixB) {
    switch (operationChoice) {
    case 0:
      try {
        SquareMatrix result = matrixA + matrixB;
        Console.WriteLine("Addition Result:");
        Console.WriteLine(result);
        Console.ReadKey();
      }
      catch (MatrixException ex) {
        Console.WriteLine($"Error: {ex.Message}");
      }

      break;
    case 1:
      try {
        SquareMatrix result = matrixA * matrixB;
        Console.WriteLine("Multiplication Result:");
        Console.WriteLine(result);
        Console.ReadKey();
      }
      catch (MatrixException ex) {
        Console.WriteLine($"Error: {ex.Message}");
      }

      break;
    default:
      if (_nextHandler != null)
        _nextHandler.HandleOperation(operationChoice, ref matrixA, ref matrixB);
      break;
    }
  }
}