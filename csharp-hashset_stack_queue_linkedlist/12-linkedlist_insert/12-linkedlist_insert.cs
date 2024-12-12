using System;
using System.Collections.Generic;

class LList {
    public static LinkedListNode<int> Insert(LinkedList<int> myLList, int n) {
        LinkedListNode<int> current = myLList.First;

        if (myLList.First == null) {
            return myLList.AddFirst(n);
        }

        while (current != null) {
            if (current.Value > n) {
                return myLList.AddBefore(current, n);
            }
            current = current.Next;
        }
        return myLList.AddLast(n);
    }
}