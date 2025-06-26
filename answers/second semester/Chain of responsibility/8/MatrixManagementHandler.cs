namespace Delegates_and_Events;

public class MatrixManagementHandler : MatrixOperationHandler {
  public override void HandleOperation(int operationChoice, ref SquareMatrix matrixA, ref SquareMatrix matrixB) {
    //the god of optimization gonna kill me
    var creationMatrixMenu = new CreationMatrixMenu(Data.MatrixMenuFillTypeItems);
    var sizeMenu = new Menu(Data.MatrixMenuSizeItems);
    int sizeChoice = -1;
    switch (operationChoice) {
    case 8:
      sizeMenu.OnItemSelected += choice => { sizeChoice = choice; };
      sizeMenu.Show();
      if (sizeChoice == 0) {
        matrixA = creationMatrixMenu.CreateMatrixWithNewSize();
        matrixB = creationMatrixMenu.CreateMatrixWithOldSize(matrixA.Size);
      }
      else {
        matrixA = creationMatrixMenu.CreateMatrixWithOldSize(matrixA.Size);
      }

      break;
    case 9:
      sizeMenu.OnItemSelected += choice => { sizeChoice = choice; };
      sizeMenu.Show();
      if (sizeChoice == 0) {
        matrixA = creationMatrixMenu.CreateMatrixWithNewSize();
        matrixB = creationMatrixMenu.CreateMatrixWithOldSize(matrixA.Size);
      }
      else {
        matrixB = creationMatrixMenu.CreateMatrixWithOldSize(matrixB.Size);
      }

      break;
    case 10:
      Console.Clear();
      Console.WriteLine($"Matrix A\n{matrixA}\n");
      Console.WriteLine($"Matrix B\n{matrixB}\n");
      Console.ReadKey();
      break;
    case 11:
      Environment.Exit(0);
      break;
    }
  }
}