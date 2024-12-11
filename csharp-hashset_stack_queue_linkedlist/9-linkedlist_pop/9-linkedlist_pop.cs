using System;
using System.Collections.Generic;

class LList {
    public static int Pop(LinkedList<int> myLList) {
        LinkedListNode<int> head = myLList.First;
        myLList.RemoveFirst();
        return head.Value;
    }
}