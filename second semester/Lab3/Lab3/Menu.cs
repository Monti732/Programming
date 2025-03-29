namespace Lab3;

public abstract class Menu {
  protected string[] _menuItems;
  protected int _selectedIndex;
  protected int _row, _col;

  protected Menu(string[] items) {
    _menuItems = items;
    _selectedIndex = 0;
  }

  public virtual void Show() {
    _row = Console.CursorTop;
    _col = Console.CursorLeft;

    while (true) {
      DrawMenu();
      switch (Console.ReadKey(true).Key) {
      case ConsoleKey.DownArrow:
        if (_selectedIndex < _menuItems.Length - 1)
          _selectedIndex++;
        break;
      case ConsoleKey.UpArrow:
        if (_selectedIndex > 0)
          _selectedIndex--;
        break;
      case ConsoleKey.Enter:
        return;
      }
    }
  }

  private void DrawMenu() {
    Console.SetCursorPosition(_col, _row);
    for (int counter = 0; counter < _menuItems.Length; counter++) {
      if (counter == _selectedIndex) {
        Console.BackgroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Black;
      }

      Console.WriteLine(_menuItems[counter]);
      Console.ResetColor();
    }

    Console.WriteLine();
  }

  public int GetSelectedIndex() {
    return _selectedIndex;
  }
}