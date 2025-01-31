using System;

class MatrixMath {
    public static double[,] Multiply(double[,] matrix1, double[,] matrix2) {
        if (matrix1.GetLength(1) != matrix2.GetLength(0)) return new double[,] {{-1}};

        double[,] result = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
        double sum = 0;

        for (int rows = 0; rows < matrix1.GetLength(0); rows++) {
            for (int cols = 0; cols < matrix2.GetLength(1); cols++) {
                sum = 0;
                for (int i=0; i < matrix1.GetLength(1); i++) {
                    sum += matrix1[rows, i] * matrix2[i, cols];
                }
                result[rows, cols] = sum;
            }
        }
        return result;
    }
}