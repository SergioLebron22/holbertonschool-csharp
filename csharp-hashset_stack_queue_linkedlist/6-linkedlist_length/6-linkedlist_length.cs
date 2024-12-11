using System;
using System.Collections.Generic;

class LList {
    public static int Length(LinkedList<int> myLList) {
        int length = 0;
        LinkedListNode<int> current = myLList.First;

        while (current != null) {
            length++;
            current = current.Next;
        }

        return length;
    }
}
