namespace Delegates_and_Events;

class Program {
  static void Main() {
    var initMenu = new CreationMatrixMenu(Data.MatrixMenuFillTypeItems);
    SquareMatrix matrixA = initMenu.CreateMatrixWithNewSize();
    SquareMatrix matrixB = initMenu.CreateMatrixWithOldSize(matrixA.Size);

    var basicMatrixOperationHendler = new BasicMatrixOperationHandler();
    var singleMatrixOperationHendler = new SingleMatrixOperationHandler();
    var matrixManegementHendler = new MatrixManagementHandler();
    basicMatrixOperationHendler.SetNextHandler(singleMatrixOperationHendler);
    singleMatrixOperationHendler.SetNextHandler(matrixManegementHendler);
    matrixManegementHendler.SetNextHandler(matrixManegementHendler);
    
    Console.Clear();
    
    var mainMenu = new Menu(Data.MainMenuItems);
    mainMenu.OnItemSelected += choice => { basicMatrixOperationHendler.HandleOperation(choice, ref matrixA, ref matrixB); };
    while (true) {
      Console.Clear();
      mainMenu.Show();
    }
  }
}