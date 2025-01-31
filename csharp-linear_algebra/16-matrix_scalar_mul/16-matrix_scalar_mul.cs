using System;

class MatrixMath {
    public static double[,] MultiplyScalar(double[,] matrix, double scalar) {
        if (matrix.GetLength(0) == matrix.GetLength(1) && (matrix.GetLength(0) == 2 || matrix.GetLength(0) == 3) ) {

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
        return new double[,] {{-1}};
    }
}