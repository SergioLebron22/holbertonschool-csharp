using System;

class VectorMath
{
    public static double[] CrossProduct(double[] vector1, double[] vector2)
    {
        if (vector1.Length != 3 || vector2.Length != 3)
            return new double[] { -1 };

        double x = Math.Round((vector1[1] * vector2[2]) - (vector1[2] * vector2[1]), 2);
        double y = Math.Round((vector1[2] * vector2[0]) - (vector1[0] * vector2[2]), 2);
        double z = Math.Round((vector1[0] * vector2[1]) - (vector1[1] * vector2[0]), 2);

        return new double[] { x, y, z };
    }
}