namespace lab1;

class Menu
{
  private string[] _menuItems;
  private int _selectedIndex;
  private int _row, _col;

  public Menu(string[] items)
  {
    _menuItems = items;
    _selectedIndex = 0;
  }

  public void Show()
  {
    Console.Clear();
    Console.WriteLine("Menu\n");

    _row = Console.CursorTop;
    _col = Console.CursorLeft;

    while (true)
    {
      DrawMenu();
      switch (Console.ReadKey(true).Key)
      {
        case ConsoleKey.DownArrow:
          if (_selectedIndex < _menuItems.Length - 1)
            _selectedIndex++;
          break;
        case ConsoleKey.UpArrow:
          if (_selectedIndex > 0)
            _selectedIndex--;
          break;
        case ConsoleKey.Enter:
          HandleSelection();
          return;
      }
    }
  }

  private void DrawMenu()
  {
    Console.SetCursorPosition(_col, _row);
    for (int i = 0; i < _menuItems.Length; i++)
    {
      if (i == _selectedIndex)
      {
        Console.BackgroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Black;
      }

      Console.WriteLine(_menuItems[i]);
      Console.ResetColor();
    }
    Console.WriteLine();
  }

  private void HandleSelection()
  {
    Console.Clear();
    Console.WriteLine($"Selected: {_menuItems[_selectedIndex]}");

    if (_selectedIndex == _menuItems.Length - 1)
    {
      Console.WriteLine("Exiting program...");
      Environment.Exit(0);
    }
  }

  public int GetSelectedIndex()
  {
    return _selectedIndex;
  }
}