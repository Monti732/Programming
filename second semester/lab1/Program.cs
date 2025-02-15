using lab1;

class Program
{
    static void Main()
    {
        string[] menuItems = {
            "Raise the number A to the power N",
            "Find number N given number X",
            "Exit the program"
        };

        Menu menu = new Menu(menuItems);

        while (true)
        {
            menu.Show();
            int choice = menu.GetSelectedIndex();

            switch (choice)
            {
                case 0:
                    MultiplyNumbers();
                    break;
                case 1:
                    FindNNumber();
                    break;
                case 2:
                    return;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    break;
            }

            Console.WriteLine("To continue press any key...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }

    private static void MultiplyNumbers()
    {
        Console.Clear();
        Console.Write("Enter a degree base: ");

        if (!int.TryParse(Console.ReadLine(), out int baseNumber))
        {
            Console.WriteLine("Invalid input. Please enter an integer.");
            return;
        }

        Console.Write("Enter a power: ");
        if (!int.TryParse(Console.ReadLine(), out int exponent))
        {
            Console.WriteLine("Invalid input. Please enter an integer.");
            return;
        }

        int result = 1;

        while (exponent > 0)
        {
            result *= baseNumber;
            exponent--;
        }

        Console.WriteLine($"Result: {result}\n");
    }

    private static void FindNNumber()
    {
        Console.Clear();
        Console.Write("Enter a number X (at least 2 digits): ");

        if (!int.TryParse(Console.ReadLine(), out int xNumber) || xNumber < 10)
        {
            Console.WriteLine("Invalid input. Number must have at least 2 digits.");
            return;
        }

        string stringXNumber = xNumber.ToString();
        char secondDigit = stringXNumber[1];
        string result = stringXNumber.Remove(1, 1) + secondDigit;

        Console.WriteLine($"Result: {result}\n");
    }
}
