using System;

class MatrixMath {
    public static double[,] MultiplyScalar(double[,] matrix, double scalar) {
        if (matrix.Rank != 2 && matrix.Rank != 3) return new double[,] {{-1}};

        int cols = matrix.GetLength(0);
        int rows = matrix.GetLength(1);

        double[,] result = new double[cols, rows];

        for (int i=0; i < cols; i++) {
            for (int j = 0; j < rows; j++) {
                result[i,j] *= scalar;
            }
        }

        return result;
    }
}