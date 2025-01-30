using System;

class VectorMath {
    public static double DotProduct(double[] vector1, double[] vector2) {
        if (vector1.Length == 2 && vector2.Length == 2 || vector1.Length == 3 && vector2.Length == 3) {

            double result = 0;
            for(int i=0; i < vector1.Length; i++){
                result += vector1[i] * vector2[i];
            }
            return result;
        }
    }
}