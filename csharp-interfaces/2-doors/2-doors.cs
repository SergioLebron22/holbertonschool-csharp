using System;

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