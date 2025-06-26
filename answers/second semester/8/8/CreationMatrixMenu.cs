namespace Delegates_and_Events;

public class CreationMatrixMenu : Menu {
  public CreationMatrixMenu(string[] menuItems) : base(menuItems) {}
  

  public SquareMatrix ShowInitialMenu() {
    Console.WriteLine("WELCOME TO GIGA MATRIX CALCULATOR 2.0\n\nEnter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    Console.WriteLine("\nHow would you like to create a Matrices?\n");
    Show();
    return new SquareMatrix(size, selectedIndex);
  }

  public SquareMatrix CreateMatrixWithNewSize() {
    Console.Clear();
    Console.WriteLine("Enter the size of the matrix: ");
    int size = Convert.ToInt32(Console.ReadLine());
    Show();
    return new SquareMatrix(size, selectedIndex);
  }

  public SquareMatrix CreateMatrixWithOldSize(int size) {
    Console.Clear();
    Show();
    return new SquareMatrix(size, selectedIndex);
  }
}