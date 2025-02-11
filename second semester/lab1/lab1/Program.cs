using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine(
                "Выберите вариант:\n1.Возвести число A в степень N\n2.Найти число N по заданному числу X\n\nВаш выбор "
            );
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:

                    Console.Write("Введите основание: ");
                    int baseNumber = int.Parse(Console.ReadLine());

                    Console.Write("Введите показатель степени: ");
                    int exponent = int.Parse(Console.ReadLine());

                    int result = MultNumbers(baseNumber, exponent);

                    Console.WriteLine($"Результат: {result}");
                    break;
            }
        }
    }

    static int MultNumbers(int baseNumber, int exponent)
    {
        int result = 1;

        for (int i )
        {

        }
    }
}