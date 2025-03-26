using System;
using System.Collections.Generic;

/// <summary>
/// Base class
/// </summary>
abstract class Base
{
    public string name { get; set; }

    /// <summary>
    /// Override ToString method
    /// </summary>
    /// <returns>string</returns>
    public override string ToString()
    {
        return $"{name} is a {this.GetType()}";
    }
}

/// <summary>
/// IInteractive interface
/// </summary>
interface IInteractive
{
    void Interact();
}

/// <summary>
/// IBreakable interface
/// </summary>
interface IBreakable
{
    int durability { get; set; }
    void Break();
}

/// <summary>
/// ICollectable interface
/// </summary>
interface ICollectable
{
    bool isCollected { get; set; }
    void Collect();
}

/// <summary>
/// TestObject class
/// </summary>
class TestObject : Base, IInteractive, IBreakable, ICollectable
{
    public int durability { get; set; }
    public bool isCollected { get; set; }

    /// <summary>
    /// Interact method implementation
    /// </summary>
    public void Interact()
    {
        Console.WriteLine("Interacting with the object.");
    }

    /// <summary>
    /// Break method implementation
    /// </summary>
    public void Break()
    {
        Console.WriteLine("Breaking the object.");
    }

    /// <summary>
    /// Collect method implementation
    /// </summary>
    public void Collect()
    {
        isCollected = true;
        Console.WriteLine("Collecting the object.");
    }
}

class Door : Base, IInteractive {
    public Door(string name = "Door") {
        this.name = name;
    }

    public void Interact() {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}

class Decoration : Base, IInteractive, IBreakable {
    public bool isQuestItem;
    public int durability {get; set;}

    public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false) {
        if (durability <= 0) {
            throw new Exception("Durability must be greater than 0");
        }
        this.name = name;
        this.durability = durability;
        this.isQuestItem = isQuestItem;
    }

    public void Interact() {
        if (durability <= 0) {
            Console.WriteLine($"The {name} has been broken.");
        }
        else if (isQuestItem) {
            Console.WriteLine($"You look at the {name}. There's a key inside.");
        }
        else {
            Console.WriteLine($"You look at the {name}. Not much to see here.");
        }
    }

    public void Break() {
        durability--;
        if (durability > 0) {
            Console.WriteLine($"You hit the {name}. It cracks.");
        }
        else if (durability == 0) {
            Console.WriteLine($"You smash the {name}. What a mess.");
        }
        else {
            Console.WriteLine($"The {name} is already broken.");
        }
    }
}

class Key : Base, ICollectable {

    public bool isCollected {get; set;}
    public Key(string name = "Key", bool isCollected = false) {
        this.name = name;
        this.isCollected = isCollected;
    }

    public void Collect() {
        if (isCollected) {
            Console.WriteLine($"You have already picked up the {name}.");
        }
        else {
            isCollected = true;
            Console.WriteLine($"You pick up the {name}.");
        }
    }
}

class RoomObjects {
    public static void IterateAction(List<Base> roomObjects, Type type) {
        foreach (Base obj in roomObjects) {
            if (type.IsInstanceOfType(obj)){
                if (obj is IInteractive interactiveObj) {
                    interactiveObj.Interact();
                }
                if (obj is IBreakable breakableObj) {
                    breakableObj.Break();
                }
                if (obj is ICollectable collectableObj) {
                    collectableObj.Collect();
                }
            }
        }
    }
}