using System;

abstract class Base {
    public string name;

    public override string ToString() {
        return $"{name} is a {this.GetType().Name}";
    }
}

interface IInteractive {
    void Interact();
}

interface IBreakable {
    int durability {get; set;}
    void Break();
}

interface ICollectable {
    bool isCollected {get;}
    void Collect();
}

class TestObject : Base, IInteractive, IBreakable, ICollectable {
    public int durability {get; set;}
    public bool isCollected {get; set;}
    public string name {get; set;}
    class TestObject : Base, IInteractive, IBreakable, ICollectable {
    public int durability { get; set; }
    public bool isCollected { get; set; }

    public void Interact() {
        Console.WriteLine("Interacting with the object.");
    }

    public void Break() {
        Console.WriteLine("Breaking the object.");
    }

    public void Collect() {
        isCollected = true;
        Console.WriteLine("Collecting the object.");
    }
}
}

