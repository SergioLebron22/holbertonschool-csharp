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
    
}

