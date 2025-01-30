using System;

class VectorMath {
    public static double[] Add(double[] vector1, double[] vector2) {
        
        if (vector1.Length == 2 && vector2.Length == 2 || vector1.Length == 3 && vector2.Length == 3){

            for (int i=0; i < vector1.Length; i++) {
                vector1[i] += vector2[i];
            }

            return vector1;
        }

        return new double[] { -1 };
    }
}