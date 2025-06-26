namespace Delegates_and_Events;

public class SquareMatrix : ICloneable, IComparable<SquareMatrix> {
  private readonly int _size;
  private double[,] _matrix;

  public int Size => _size;
  public double[,] Matrix => _matrix;

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
      for (int rows = 0; rows < _size; ++rows) {
        for (int cols = 0; cols < _size; ++cols) {
          while (true) {
            try {
              Console.WriteLine("Enter elements of the matrix:");
              Console.Write($"Element [{rows},{cols}]: ");
              int value = int.Parse(Console.ReadLine());

              if (value > maxValue || value < minValue) {
                throw new ArgumentOutOfRangeException(
                  $"Value {value} is not acceptable! Alloed range: [{minValue}, {maxValue}]");
              }

              _matrix[rows, cols] = value;

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
      for (int rows = 0; rows < size; ++rows) {
        for (int cols = 0; cols < size; ++cols) {
          _matrix[rows, cols] = rnd.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue));
        }
      }
    }
  }


  private static double[,] DeepCopy(double[,] source) {
    int rowsCount = source.GetLength(0);
    int colsCount = source.GetLength(1);
    double[,] copy = new double[rowsCount, colsCount];

    for (int rows = 0; rows < rowsCount; ++rows) {
      for (int cols = 0; cols < colsCount; ++cols) {
        copy[rows, cols] = source[rows, cols];
      }
    }

    return copy;
  }

  public object Clone() => new SquareMatrix(this);
  
  public double Determinant() {
    if (_size == 1) return _matrix[0, 0];

    double det = 0;
    for (int col = 0; col < _size; ++col) {
      SquareMatrix minor = GetMinor(this, 0, col);
      det += ((col % 2 == 0) ? 1 : -1) * _matrix[0, col] * minor.Determinant();
    }

    return det;
  }

  private SquareMatrix GetMinor(SquareMatrix matrix, int minorRow, int minorCol) {
    int size = matrix.Size;
    SquareMatrix minor = new SquareMatrix(size - 1);

    for (int row = 0, minorI = 0; row < size; row++) {
      if (row == minorRow) continue;
      for (int col = 0, minorJ = 0; col < size; col++) {
        if (col == minorCol) continue;
        minor._matrix[minorI, minorJ] = matrix._matrix[row, col];
        ++minorJ;
      }

      ++minorI;
    }

    return minor;
  }

  private SquareMatrix Adjoint() {
    int size = this.Size;
    SquareMatrix adjoint = new SquareMatrix(size);

    for (int row = 0; row < size; row++) {
      for (int col = 0; col < size; col++) {
        SquareMatrix minor = GetMinor(this, row, col);
        double minorDet = minor.Determinant();

        int sign = (row + col) % 2 == 0 ? 1 : -1;

        adjoint._matrix[col, row] = sign * minorDet;
      }
    }

    return adjoint;
  }

  public SquareMatrix Inverse() {
    double det = Determinant();
    if (det == 0) {
      throw new MatrixException("Inverse matrix doesn't exist, determinant is zero!");
    }

    int size = Size;
    SquareMatrix inverse = new SquareMatrix(size);
    SquareMatrix adjoint = Adjoint();

    for (int row = 0; row < size; row++) {
      for (int col = 0; col < size; col++) {
        inverse._matrix[row, col] = adjoint._matrix[row, col] / det;
      }
    }

    return inverse;
  }

  public static SquareMatrix operator +(SquareMatrix left, SquareMatrix right) {
    if (left.Size != right.Size) throw new MatrixException("Matrix size mismatch!");

    SquareMatrix result = new SquareMatrix(left.Size);
    for (int row = 0; row < left.Size; ++row) {
      for (int col = 0; col < left.Size; ++col) {
        result._matrix[row, col] = left._matrix[row, col] + right._matrix[row, col];
      }
    }

    return result;
  }

  public static SquareMatrix operator *(SquareMatrix left, SquareMatrix right) {
    if (left.Size != right.Size) throw new MatrixException("Matrix size mismatch!");

    SquareMatrix result = new SquareMatrix(left.Size);
    for (int row = 0; row < left.Size; ++row) {
      for (int col = 0; col < left.Size; ++col) {
        for (int index = 0; index < left.Size; index++) {
          result._matrix[row, col] += left._matrix[row, index] * right._matrix[index, col];
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
    for (int row = 0; row < left.Size; ++row) {
      for (int col = 0; col < left.Size; ++col) {
        if (left._matrix[row, col] != right._matrix[row, col])
          return false;
      }
    }

    return true;
  }

  public static bool operator !=(SquareMatrix left, SquareMatrix right) => !(left == right);

  public override string ToString() {
    string result = "";
    for (int row = 0; row < _size; ++row) {
      for (int col = 0; col < _size; ++col)
        result += $"{_matrix[row, col],6:F2} ";
      result += "\n";
    }

    return result;
  }

  public int CompareTo(SquareMatrix other) => Determinant().CompareTo(other.Determinant());
  public override bool Equals(object obj) => obj is SquareMatrix matrix && this == matrix;
  public override int GetHashCode() => Determinant().GetHashCode();


  public static explicit operator string(SquareMatrix matrix) {
    string result = "";
    for (int row = 0; row < matrix._size; ++row) {
      for (int col = 0; col < matrix._size; ++col)
        result += $"{matrix._matrix[row, col]} ";
    }

    return result;
  }

  public static bool operator true(SquareMatrix matrix) {
    for (int row = 0; row < matrix.Size; ++row) {
      for (int col = 0; col < matrix.Size; ++col) {
        if (matrix._matrix[row, col] != 0) return true;
      }
    }

    return false;
  }

  public static bool operator false(SquareMatrix matrix) {
    for (int row = 0; row < matrix.Size; ++row) {
      for (int col = 0; col < matrix.Size; ++col) {
        if (matrix._matrix[row, col] == 0) return false;
      }
    }

    return true;
  }
}