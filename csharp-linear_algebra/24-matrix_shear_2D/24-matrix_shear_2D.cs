using System;


class MatrixMath
{
    public static double[,] Shear2D(double[,] matrix, char direction, double factor)
    {
        int cols = matrix.GetLength(0);
        int rows = matrix.GetLength(1);
        double[,] result = new double[2, 2];
        double sum;


        if (cols != 2 || rows != 2)
            return new double[,] { { -1 } };

        if (char.ToLower(direction) != 'y' && char.ToLower(direction) != 'x')
            return new double[,] { { -1 } };

        if (factor < 0)
            return new double[,] { { -1 } };

        double[,] shear = new double[,] { { 1, direction == 'x' ? factor : 0 }, { direction == 'y' ? factor : 0, 1 } };
        matrix = new double[2,2]{{matrix[0,0], matrix[1,0]},{matrix[0,1], matrix[1,1]}};

        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                sum = 0;
                for (int i = 0; i < cols; i++)
                {
                    sum += shear[col, i] * matrix[i, row];
                }
                result[col, row] = Math.Round(sum, 2);
            }
        }
        result = new double[2,2]{{result[0,0], result[1,0]},{result[0,1], result[1,1]}};
        return result;
    }
}