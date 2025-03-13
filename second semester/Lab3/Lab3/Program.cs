using System.Diagnostics;
using System.Runtime.CompilerServices;
using Lab3;

class Program() {
  static void Main() {
    string[] menuItems = { "Summarize matrices", "Multiply matrices", "Compare matrices", "Convert to string", };
    SquareMatrix a = new SquareMatrix(3, -5, 5, false);
    SquareMatrix b = new SquareMatrix(3, -5, 5, false);
    Console.WriteLine(a.ToString());
    Console.WriteLine(b.ToString());
    Console.WriteLine(a+b);
    Console.WriteLine(a*b);
    Console.WriteLine(a.Determinant());
  }
}