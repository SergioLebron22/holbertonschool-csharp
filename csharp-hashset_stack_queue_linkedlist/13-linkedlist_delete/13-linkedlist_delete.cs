using System;
using System.Collections.Generic;

class LList
{
    public static void Delete(LinkedList<int> myLList, int index) {
        if (index < 0 || index > myLList.Count)
            return;

        LinkedListNode<int> current = myLList.First;
        int indexCount = 0;
        
        while (current != null) {
            if (indexCount == index) {
                myLList.Remove(current);
            }
            current = current.Next;
            indexCount++;
        }
    }
}