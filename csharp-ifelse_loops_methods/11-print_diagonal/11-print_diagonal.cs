using System;

class Line {
    public static void PrintDiagonal(int length){
        int i;
        int c;

        c = 0;

        while (length > 0) {
            i = c;
            while (i > 0) {
                Console.Write(" ");
                i--;
            }
            Console.Write("\\");
            Console.Write("\n");
            c++;
            length--;
        }
        if (c < 1) {
            Console.Write("\n");
        }
    }
}