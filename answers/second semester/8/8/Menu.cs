namespace Delegates_and_Events;

public class Menu {
  private string[] _menuItems;
  protected int selectedIndex;
  private int _row, _col;
  
  public event Action<int>? OnItemSelected;
  
  public Menu(string[] items) {
    _menuItems = items;
    selectedIndex = 0;
  }

  public void Show() {
    _row = Console.CursorTop;
    _col = Console.CursorLeft;

    while (true) {
      DrawMenu();
      switch (Console.ReadKey(true).Key) {
      case ConsoleKey.DownArrow:
        if (selectedIndex < _menuItems.Length - 1)
          selectedIndex++;
        break;
      case ConsoleKey.UpArrow:
        if (selectedIndex > 0)
          selectedIndex--;
        break;
      case ConsoleKey.Enter:
        OnItemSelected?.Invoke(selectedIndex);
        return;
      }
    }
  }

  private void DrawMenu() {
    Console.SetCursorPosition(_col, _row);
    for (int counter = 0; counter < _menuItems.Length; counter++) {
      if (counter == selectedIndex) {
        Console.BackgroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Black;
      }

      Console.WriteLine(_menuItems[counter]);
      Console.ResetColor();
    }

    Console.WriteLine();
  }
}