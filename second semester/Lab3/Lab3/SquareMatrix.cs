namespace Lab3;

public class SquareMatrix : ICloneable, IComparable<SquareMatrix> {
  private readonly int _size;
  private double[,] _matrix;

  public int Size => _size;

/*Если нам нужно реализовать матричный калькулятор то зачем нужен конструктор для ее случайной генерации?*/
  public SquareMatrix(int size, int fillByYourself) {
    _size = size;
    _matrix = new double[size, size];
    FillMatrix(size, fillByYourself);
  }

  private SquareMatrix(int size) {
    _size = size;
    _matrix = new double[size, size];
  }

  public SquareMatrix(SquareMatrix other) {
    _size = other._size;
    _matrix = DeepCopy(other._matrix);
  }

  private void FillMatrix(int size, int fillByYourself) {
    if (size <= 0) throw new MatrixException("Matrix size must be greater than 0!");

    Console.Write("Enter min and max values: ");
    double minValue = Convert.ToDouble(Console.ReadLine());
    double maxValue = Convert.ToDouble(Console.ReadLine());
    if (fillByYourself == 1) {
      for (int i = 0; i < _size; ++i) {
        for (int j = 0; j < _size; ++j) {
          while (true) {
            try {
              Console.WriteLine("Enter elements of the matrix:");

              Console.Write($"Element [{i},{j}]: ");
              int value = int.Parse(Console.ReadLine());

              if (value > maxValue || value < minValue) {
                throw new ArgumentOutOfRangeException(
                  $"Value {value} is not acceptable! Alloed range: [{minValue}, {maxValue}]");
              }

              _matrix[i, j] = value;

              break;
            }
            catch (FormatException) {
              Console.WriteLine("Invalid input! Please enter a valid number.");
              Console.ReadKey();
            }
            catch (ArgumentOutOfRangeException ex) {
              Console.WriteLine($"Error: {ex.Message}");
              Console.ReadKey();
            }
          }
        }
      }
    }

    else {
      Random rnd = new Random();
      for (int i = 0; i < size; ++i) {
        for (int j = 0; j < size; ++j) {
          _matrix[i, j] = rnd.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue));
        }
      }
    }
  }


  private static double[,] DeepCopy(double[,] source) {
    int rows = source.GetLength(0);
    int cols = source.GetLength(1);
    double[,] copy = new double[rows, cols];

    for (int i = 0; i < rows; ++i) {
      for (int j = 0; j < cols; ++j) {
        copy[i, j] = source[i, j];
      }
    }

    return copy;
  }

  public object Clone() => new SquareMatrix(this);

  public double Determinant() {
    if (_size == 1) return _matrix[0, 0];

    double det = 0;
    for (int i = 0; i < _size; ++i) {
      SquareMatrix minor = GetMinor(this, 0, i);
      det += ((i % 2 == 0) ? 1 : -1) * _matrix[0, i] * minor.Determinant();
    }

    return det;
  }

  private SquareMatrix GetMinor(SquareMatrix matrix, int row, int col) {
    int size = matrix.Size;
    SquareMatrix minor = new SquareMatrix(size - 1);

    for (int i = 0, minorI = 0; i < size; i++) {
      if (i == row) continue;
      for (int j = 0, minorJ = 0; j < size; j++) {
        if (j == col) continue;
        minor._matrix[minorI, minorJ] = matrix._matrix[i, j];
        ++minorJ;
      }

      ++minorI;
    }

    return minor;
  }

  private SquareMatrix Adjoint() {
    int size = this.Size;
    SquareMatrix adjoint = new SquareMatrix(size);

    for (int i = 0; i < size; i++) {
      for (int j = 0; j < size; j++) {
        SquareMatrix minor = GetMinor(this, i, j);
        double minorDet = minor.Determinant();

        int sign = (i + j) % 2 == 0 ? 1 : -1;

        adjoint._matrix[j, i] = sign * minorDet;
      }
    }

    return adjoint;
  }

  public SquareMatrix Inverse() {
    double det = Determinant();
    if (det == 0)
      throw new MatrixException("Inverse matrix doesn't exist, determinant is zero!");

    int size = this.Size;
    SquareMatrix inverse = new SquareMatrix(size);
    SquareMatrix adjoint = Adjoint();

    for (int i = 0; i < size; i++)
    for (int j = 0; j < size; j++)
      inverse._matrix[i, j] = adjoint._matrix[i, j] / det;

    return inverse;
  }

  public static SquareMatrix operator +(SquareMatrix left, SquareMatrix right) {
    if (left.Size != right.Size) throw new MatrixException("Matrix size mismatch!");

    SquareMatrix result = new SquareMatrix(left.Size);
    for (int i = 0; i < left.Size; ++i) {
      for (int j = 0; j < left.Size; ++j) {
        result._matrix[i, j] = left._matrix[i, j] + right._matrix[i, j];
      }
    }

    return result;
  }

  public static SquareMatrix operator *(SquareMatrix left, SquareMatrix right) {
    if (left.Size != right.Size) throw new MatrixException("Matrix size mismatch!");

    SquareMatrix result = new SquareMatrix(left.Size);
    for (int i = 0; i < left.Size; ++i) {
      for (int j = 0; j < left.Size; ++j) {
        for (int k = 0; k < left.Size; k++) {
          result._matrix[i, j] += left._matrix[i, k] * right._matrix[k, j];
        }
      }
    }

    return result;
  }

  public static bool operator >(SquareMatrix left, SquareMatrix right) => left.Determinant() > right.Determinant();
  public static bool operator <(SquareMatrix left, SquareMatrix right) => left.Determinant() < right.Determinant();
  public static bool operator >=(SquareMatrix left, SquareMatrix right) => left.Determinant() >= right.Determinant();
  public static bool operator <=(SquareMatrix left, SquareMatrix right) => left.Determinant() <= right.Determinant();

  public static bool operator ==(SquareMatrix left, SquareMatrix right) {
    if (left.Size != right.Size) return false;
    for (int i = 0; i < left.Size; ++i) {
      for (int j = 0; j < left.Size; ++j) {
        if (left._matrix[i, j] != right._matrix[i, j])
          return false;
      }
    }

    return true;
  }

  public static bool operator !=(SquareMatrix left, SquareMatrix right) => !(left == right);

  public override string ToString() {
    string result = "";
    for (int i = 0; i < _size; ++i) {
      for (int j = 0; j < _size; ++j)
        result += $"{_matrix[i, j],6:F2} ";
      result += "\n";
    }

    return result;
  }

  public int CompareTo(SquareMatrix other) => Determinant().CompareTo(other.Determinant());
  public override bool Equals(object obj) => obj is SquareMatrix matrix && this == matrix;
  public override int GetHashCode() => Determinant().GetHashCode();


  public static explicit operator string(SquareMatrix matrix) {
    string result = "";
    for (int i = 0; i < matrix._size; ++i) {
      for (int j = 0; j < matrix._size; ++j)
        result += $"{matrix._matrix[i, j]} ";
    }

    return result;
  }

  public static bool operator true(SquareMatrix matrix) {
    for (int i = 0; i < matrix.Size; ++i) {
      for (int j = 0; j < matrix.Size; ++j) {
        if (matrix._matrix[i, j] != 0) return true;
      }
    }

    return false;
  }

  public static bool operator false(SquareMatrix matrix) {
    for (int i = 0; i < matrix.Size; ++i) {
      for (int j = 0; j < matrix.Size; ++j) {
        if (matrix._matrix[i, j] == 0) return false;
      }
    }

    return true;
  }
}