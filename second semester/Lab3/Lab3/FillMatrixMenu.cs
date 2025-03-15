namespace Lab3;

public class FillMatrixMenu : Menu {
  private int _selectedIndex;

  public FillMatrixMenu(string[] items) : base(items) {
    _selectedIndex = 0;
  }

  public override void Show() {
    Console.Clear();
    base.Show();
  }

  public int GetSelectedIndex() {
    return _selectedIndex;
  }
}