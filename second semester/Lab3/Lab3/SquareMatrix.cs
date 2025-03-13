namespace Lab3;

public class SquareMatrix : ICloneable, IComparable<SquareMatrix> {
  private readonly int _size;
  private int[,] _matrix;

  public int Size => _size;

/*Если нам нужно реализовать матричный калькулятор то зачем нужен конструктор для ее случайной генерации?*/
  public SquareMatrix(int size, int minValue, int maxValue, bool fillByYourself) {
    if (size <= 0) throw new MatrixException("Matrix size must be greater than 0!");

    _size = size;
    _matrix = new int[size, size];

    if (fillByYourself) {
      for (int i = 0; i < _size; ++i) {
        for (int j = 0; j < _size; ++j) {
          while (true) {
            try {
              Console.Clear();
              Console.WriteLine("Enter elements of the matrix:");

              Console.Write($"Element [{i},{j}]: ");
              int value = int.Parse(Console.ReadLine());

              if (value > maxValue) {
                throw new ArgumentOutOfRangeException($"Value {value} is too large! Max allowed: {maxValue}");
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
          _matrix[i, j] = rnd.Next(minValue, maxValue);
        }
      }
    }
  }

  public SquareMatrix(int size) {
    _size = size;
    _matrix = new int[size, size];
  }

  public SquareMatrix(SquareMatrix other) {
    _size = other._size;
    _matrix = DeepCopy(other._matrix);
  }

  private static int[,] DeepCopy(int[,] source) {
    int rows = source.GetLength(0);
    int cols = source.GetLength(1);
    int[,] copy = new int[rows, cols];

    for (int i = 0; i < rows; ++i) {
      for (int j = 0; j < cols; ++j) {
        copy[i, j] = source[i, j];
      }
    }

    return copy;
  }

  public object Clone() => new SquareMatrix(this);

  /*I don't know why this...thing don't work, but I'd really like to find out*/
  public int Determinant() {
    if (_size == 1) return _matrix[0, 0];

    int det = 0;
    for (int i = 0; i < _size; ++i) {
      SquareMatrix minor = GetMinor(this, i, i);
      det += ((i % 2 == 0) ? 1 : -1) * _matrix[0, i] * minor.Determinant();
    }

    return det;
  }

  public SquareMatrix GetMinor(SquareMatrix matrix, int row, int col) {
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
        int minorDet = minor.Determinant();

        int sign = (i + j) % 2 == 0 ? 1 : -1;

        adjoint._matrix[j, i] = sign * minorDet;
      }
    }

    return adjoint;
  }

  public SquareMatrix Inverse() {
    int det = Determinant();
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

  public static SquareMatrix operator +(SquareMatrix a, SquareMatrix b) {
    if (a.Size != b.Size) throw new MatrixException("Matrix size mismatch!");

    SquareMatrix result = new SquareMatrix(a.Size);
    for (int i = 0; i < a.Size; ++i) {
      for (int j = 0; j < a.Size; ++j) {
        result._matrix[i, j] = a._matrix[i, j] + b._matrix[i, j];
      }
    }

    return result;
  }

  public static SquareMatrix operator *(SquareMatrix a, SquareMatrix b) {
    if (a.Size != b.Size) throw new MatrixException("Matrix size mismatch!");

    SquareMatrix result = new SquareMatrix(a.Size);
    for (int i = 0; i < a.Size; ++i) {
      for (int j = 0; j < a.Size; ++j) {
        for (int k = 0; k < a.Size; k++) {
          result._matrix[i, j] += a._matrix[i, k] * b._matrix[k, j];
        }
      }
    }

    return result;
  }

  public static bool operator >(SquareMatrix a, SquareMatrix b) => a.Determinant() > b.Determinant();
  public static bool operator <(SquareMatrix a, SquareMatrix b) => a.Determinant() < b.Determinant();
  public static bool operator >=(SquareMatrix a, SquareMatrix b) => a.Determinant() >= b.Determinant();
  public static bool operator <=(SquareMatrix a, SquareMatrix b) => a.Determinant() <= b.Determinant();

  public static bool operator ==(SquareMatrix a, SquareMatrix b) {
    if (a.Size != b.Size) return false;
    for (int i = 0; i < a.Size; ++i) {
      for (int j = 0; j < a.Size; ++j) {
        if (a._matrix[i, j] != b._matrix[i, j])
          return false;
      }
    }

    return true;
  }

  public static bool operator !=(SquareMatrix a, SquareMatrix b) => !(a == b);

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