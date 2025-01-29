using System;

class VectorMath {
    public static double Magnitude(double[] vector) {
        if (vector.Length != 2 && vector.Length != 3)
            return -1;

        double power = 0;
        foreach (double value in vector) {
            power += Math.Pow(value, 2);
        }

        double result = Math.Sqrt(power);

        return Math.Round(result, 2);
    }
}