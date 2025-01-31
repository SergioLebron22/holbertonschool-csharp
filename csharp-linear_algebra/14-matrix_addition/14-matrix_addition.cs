using System;

class MatrixMath {
    public static double[,] Add(double[,] matrix1, double[,] matrix2) {
        if (((matrix1.GetLength(0) == 2 && matrix1.GetLength(1) == 2) ||
            (matrix1.GetLength(0) == 3 && matrix1.GetLength(1) == 3)) &&
            matrix1.GetLength(0) == matrix2.GetLength(0))
        {
            int cols = matrix1.GetLength(0);
            int rows = matrix1.GetLength(1);
            double[,] resultMatrix = new double[cols,rows];

            for (int i = 0; i < cols; i++){
                for(int j = 0; j < rows; j++) {
                    resultMatrix[i,j] = matrix1[i,j] + matrix2[i,j];
                }
            }
            return resultMatrix;
        }
        return new double[,] {{-1}};
    }
}