using System;


class MatrixMath
{
    public static double Determinant(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (matrix.GetLength(1) > 3 || matrix.GetLength(1) != matrix.GetLength(0))
            return -1;

        if (cols == 2)
            return Math.Round(matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0], 2);

        double matrixA = matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]);
        double matrixB = matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]);
        double matrixC = matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);

        return Math.Round(matrixA - matrixB + matrixC, 2);
    }
}