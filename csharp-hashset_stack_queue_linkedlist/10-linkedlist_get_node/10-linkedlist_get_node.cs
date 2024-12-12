using System;
using System.Collections.Generic;

class LList {
    public static int GetNode(LinkedList<int> myLList, int n) {
        
        LinkedListNode<int> current = myLList.First;
        for (int i=0; i < myLList.Count; i++) {
            if (n == i) {
                return current.Value;
            }
            current = current.Next;
        }
        return 0;
    }
}