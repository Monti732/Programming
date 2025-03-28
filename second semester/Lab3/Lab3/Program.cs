using Lab3;

class Program() {
  static void Main() {
    MenuItems mainMenuItems = new MenuItems();
    MainMenu mainMenu = new MainMenu(mainMenuItems.MainMenuItems);
    mainMenu.Show();
  }
}