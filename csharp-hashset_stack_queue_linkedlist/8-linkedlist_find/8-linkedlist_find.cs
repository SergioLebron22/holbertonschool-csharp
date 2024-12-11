using System;
using System.Collections.Generic;

class LList {
    public static int FindNode(LinkedList<int> myLList, int value) {
        int idx = 0;
        LinkedListNode<int> current = myLList.First;

        while (current.Value != value) {
            idx++;
            current = current.Next;

            if (current.Next == null) {
                return -1;
            }
        }

        return idx;
    }
}