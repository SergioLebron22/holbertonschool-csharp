using System;


class MatrixMath
{
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double sin = Math.Sin(angle);
        double cos = Math.Cos(angle);
        double sum;
        double[,] result = new double[rows, cols];

        if (rows != 2 || cols != 2)
            return new double[,] { { -1 } };

        double[,] SinCosMatrix = { { cos, sin }, { -sin, cos } };

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                sum = 0;
                for (int i = 0; i < cols; i++)
                {
                    sum += matrix[row, i] * SinCosMatrix[i, col];
                }
                result[row, col] = Math.Round(sum, 2);
            }
        }
        return result;
    }
}