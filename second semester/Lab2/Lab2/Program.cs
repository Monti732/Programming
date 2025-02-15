using Lab2;

class Program() {
  static void Main() {
    string[] menuItens = {
      "MS Word",
      "PDF",
      "MS Excel",
      "TXT",
      "HTML",
      "Exit program"
    };

    Menu menu = new Menu(menuItens);

    while (true) {
      menu.Show();
      int choce = menu.GetSelectedIndex();

      
    }
  }
}