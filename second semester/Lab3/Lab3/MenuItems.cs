namespace Lab3;

public struct MenuItems {
  public readonly string[] MainMenuItems = [
    "Summarize matrices", "Multiply matrices", "Compare matrices", "Convert to string", "Check if matrix is zero",
    "Find determinant",
    "Find inverse matrix", "Clone matrix", "Exit the program"
  ];

  public readonly string[] FillMatrixItems = ["Fill Automatically", "Fill By Yourself"];
  public MenuItems() {}
}