namespace Delegates_and_Events;

public static class SquareMatrixExtensionMethods {
    public static SquareMatrix Transpose(this SquareMatrix matrix) {
        SquareMatrix transposeMatrix = new SquareMatrix(matrix);
        for (int row = 0; row < matrix.Size; ++row) {
            for (int col = 0; col < matrix.Size; ++col) {
                transposeMatrix.Matrix[row, col] = matrix.Matrix[col, row];
            }
        }

        return transposeMatrix;
    }
    
    public static double FindTrace(this SquareMatrix matrix) {
        double trace = 0;
        for (int row = 0; row < matrix.Size; ++row) {
            trace += matrix.Matrix[row, row];
        }

        return trace;
    }
}