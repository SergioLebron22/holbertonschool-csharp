using System;

/// <summary>Contains methods to perform matrix operations</summary>
class MatrixMath
{
    /// <summary>Multiplies a matrix and a scalar</summary>
    /// <param name="matrix">Matrix to multiply</param>
    /// <param name="scalar">Scalar to multiply</param>
    /// <returns>Resulting matrix</returns>
    public static double[,] MultiplyScalar(double[,] matrix, double scalar)
    {
        if (matrix.GetLength(0) == matrix.GetLength(1) && (matrix.GetLength(0) == 2 || matrix.GetLength(0) == 3))
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= scalar;
                }
            }
            return matrix;
        }
        return new double[,] {{-1}};
    }
}