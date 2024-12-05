using System;

class Array {
    public static int[] CreatePrint(int size) {
        if (size < 0){
            Console.WriteLine("Size cannot be negative");
            return null;
        }
        else if (size == 0) {
            Console.WriteLine();
            return new int[0];
        }
        else {
            int[] array = new int[size];
            for (int i = 0; i < size; i++) {
                array[i] = i;
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            return array;
        }
    }
}