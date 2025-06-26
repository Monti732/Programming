namespace Delegates_and_Events;

public abstract class MatrixOperationHandler {
  protected MatrixOperationHandler _nextHandler;

  public void SetNextHandler(MatrixOperationHandler handler) {
    _nextHandler = handler;
  }

  public abstract void HandleOperation(int operationChoice, ref SquareMatrix matrixA, ref SquareMatrix matrixB);
}