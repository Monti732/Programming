namespace Lab3;

public class SquareMatrix : ICloneable, IComparable<SquareMatrix> {
  private readonly int _size;
  private double[,] _matrix;

  public int Size => _size;
  public double[,] Matrix => _matrix;

  // 🔹 Конструктор: Создание случайной матрицы
  public SquareMatrix(int size, int minValue, int maxValue) {
    if (size <= 0) throw new MatrixException("Размер матрицы должен быть больше нуля!");

    _size = size;
    _matrix = new double[size, size];

    Random rnd = new Random();
    for (int i = 0; i < size; i++)
    for (int j = 0; j < size; j++)
      _matrix[i, j] = rnd.Next(minValue, maxValue);
  }

  public SquareMatrix(int size) {
    _size = size;
    _matrix = new double[size, size];
  }
  
  // 🔹 Конструктор копирования (Прототип)
  public SquareMatrix(SquareMatrix other) {
    _size = other._size;
    _matrix = (double[,])other._matrix.Clone();
  }

  // 🔹 Перегрузка оператора "+"
  public static SquareMatrix operator +(SquareMatrix a, SquareMatrix b) {
    if (a.Size != b.Size) throw new MatrixException("Размеры матриц должны совпадать!");

    SquareMatrix result = new SquareMatrix(a.Size);
    for (int i = 0; i < a.Size; i++)
    for (int j = 0; j < a.Size; j++)
      result._matrix[i, j] = a._matrix[i, j] + b._matrix[i, j];

    return result;
  }

  // 🔹 Перегрузка оператора "*"
  public static SquareMatrix operator *(SquareMatrix a, SquareMatrix b) {
    if (a.Size != b.Size) throw new MatrixException("Размеры матриц должны совпадать!");

    SquareMatrix result = new SquareMatrix(a.Size);
    for (int i = 0; i < a.Size; i++)
    for (int j = 0; j < a.Size; j++)
    for (int k = 0; k < a.Size; k++)
      result._matrix[i, j] += a._matrix[i, k] * b._matrix[k, j];

    return result;
  }

  // 🔹 Нахождение детерминанта (рекурсивный метод)
  public double Determinant() {
    if (_size == 1) return _matrix[0, 0];

    double det = 0;
    for (int i = 0; i < _size; i++) {
      SquareMatrix minor = GetMinor(this, i);
      det += ((i % 2 == 0) ? 1 : -1) * _matrix[0, i] * minor.Determinant();
    }

    return det;
  }

  // 🔹 Получение минора для детерминанта
  private static SquareMatrix GetMinor(SquareMatrix matrix, int col) {
    SquareMatrix minor = new SquareMatrix(matrix._size - 1);
    for (int i = 1; i < matrix._size; i++)
    for (int j = 0, minorJ = 0; j < matrix._size; j++)
      if (j != col)
        minor._matrix[i - 1, minorJ++] = matrix._matrix[i, j];

    return minor;
  }

  // 🔹 Перегрузка операторов сравнения (по детерминанту)
  public static bool operator >(SquareMatrix a, SquareMatrix b) => a.Determinant() > b.Determinant();
  public static bool operator <(SquareMatrix a, SquareMatrix b) => a.Determinant() < b.Determinant();
  public static bool operator >=(SquareMatrix a, SquareMatrix b) => a.Determinant() >= b.Determinant();
  public static bool operator <=(SquareMatrix a, SquareMatrix b) => a.Determinant() <= b.Determinant();

  // 🔹 Операторы равенства и неравенства
  public static bool operator ==(SquareMatrix a, SquareMatrix b) {
    if (a.Size != b.Size) return false;
    for (int i = 0; i < a.Size; i++)
    for (int j = 0; j < a.Size; j++)
      if (a._matrix[i, j] != b._matrix[i, j])
        return false;
    return true;
  }

  public static bool operator !=(SquareMatrix a, SquareMatrix b) => !(a == b);

  // 🔹 Преобразование в строку
  public override string ToString() {
    string result = "";
    for (int i = 0; i < _size; i++) {
      for (int j = 0; j < _size; j++)
        result += $"{_matrix[i, j],6:F2} ";
      result += "\n";
    }

    return result;
  }

  // 🔹 Реализация интерфейсов
  public int CompareTo(SquareMatrix other) => Determinant().CompareTo(other.Determinant());
  public override bool Equals(object obj) => obj is SquareMatrix matrix && this == matrix;
  public override int GetHashCode() => Determinant().GetHashCode();

  // 🔹 Реализация паттерна "Прототип" (глубокое копирование)
  public object Clone() => new SquareMatrix(this);
}