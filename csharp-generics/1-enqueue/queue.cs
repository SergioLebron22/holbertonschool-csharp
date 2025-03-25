using System;


public class Queue<T> 
{

    public Type CheckType() {
        return typeof(T);
    } 

    public class Node {

        public T value;
        public Node? next = null;

        public Node(T value) {
            this.value = value;
        }
    }

    public Node? head;
    public Node? tail;
    public int count = 0;

    public void Enqueue(T value) {
        Node newNode = new Node(value);

        if (head == null) {
            head = newNode;
            tail = newNode;
        }
        else {
            tail!.next = newNode;
            tail = newNode;
        }

        count++;
    }

    public int Count() {
        return count;
    }


}