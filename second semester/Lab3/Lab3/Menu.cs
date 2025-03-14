namespace Lab3;

class Menu {
  private string[] _menuItems;
  private int _selectedIndex;
  private int _row, _col;

  public Menu(string[] items) {
    _menuItems = items;
    _selectedIndex = 0;
  }

  public void Show() {
    Console.Clear();
    Console.WriteLine("ULTRA MEGA CALCULATOR\n");
    
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