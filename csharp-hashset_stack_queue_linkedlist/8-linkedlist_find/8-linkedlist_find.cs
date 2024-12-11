using System;
using System.Collections.Generic;

class LList {
    public static int FindNode(LinkedList<int> myLList, int value) {
        int count = 0;
        foreach (int num in myLList) {
            if (value == num) {
                return count;
            }
            count++;
        }
        return -1;
    }
}