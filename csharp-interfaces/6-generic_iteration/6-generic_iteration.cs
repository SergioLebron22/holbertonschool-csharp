using System;
using System.Collections;
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
/// Door class
/// </summary>
class Door : Base, IInteractive
{
    public Door(string value = "Door")
    {
        this.name = value;
    }

    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}

/// <summary>
/// Decoration class
/// </summary>
class Decoration : Base, IInteractive, IBreakable
{
    public bool isQuestItem { get; set; }
    public int durability { get; set; }

    /// <summary>
    /// Decoration constructor
    /// </summary>
    /// <param name="name">name of the decoration</param>
    /// <param name="durability">durability of the decoration</param>
    /// <param name="isQuestItem">chack if is a quest item</param>
    /// <exception cref="Exception">durabilyty needs to be more that 0</exception>
    public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false)
    {
        if (durability <= 0)
        {
            throw new Exception("Durability must be greater than 0");
        }
        this.name = name;
        this.durability = durability;
        this.isQuestItem = isQuestItem;
    }

    /// <summary>
    /// Interact method
    /// </summary>
    public void Interact()
    {
        if (durability <= 0)
        {
            Console.WriteLine($"The {name} has been broken.");
        }
        else if (isQuestItem)
        {
            Console.WriteLine($"You look at the {name}. There's a key inside.");
        }
        else
        {
            Console.WriteLine($"You look at the {name}. Not much to see here.");
        }
    }

    /// <summary>
    /// Break method
    /// </summary>
    public void Break()
    {
        durability--;
        if (durability > 0)
        {
            Console.WriteLine($"You hit the {name}. It cracks.");
        }
        else if (durability == 0)
        {
            Console.WriteLine($"You smash the {name}. What a mess.");
        }
        else
        {
            Console.WriteLine($"The {name} is already broken.");
        }
    }
}

/// <summary>
/// Key class
/// </summary>
class Key : Base, ICollectable
{
    public bool isCollected { get; set; }

    /// <summary>
    /// Key constructor
    /// </summary>
    /// <param name="name">name of the key</param>
    /// <param name="isCollected">check if is collected</param>
    public Key(string name = "Key", bool isCollected = false)
    {
        this.name = name;
        this.isCollected = isCollected;
    }

    /// <summary>
    /// Collect method
    /// </summary>
    public void Collect()
    {
        if (!isCollected)
        {
            isCollected = true;
            Console.WriteLine($"You pick up the {name}.");
        }
        else
        {
            Console.WriteLine($"You have already picked up the {name}.");
        }
    }
}

/// <summary>
/// Objs class
/// </summary>
/// <typeparam name="T">type of the objs</typeparam>
class Objs<T> : IEnumerable<T>
{
    List<T> objs = new List<T>();

    /// <summary>
    /// Add method
    /// </summary>
    /// <param name="obj">obj to add</param>
    public void Add(T obj)
    {
        objs.Add(obj);
    }

    /// <summary>
    /// GetEnumerator method
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator<T> GetEnumerator()
    {
        foreach (T obj in objs)
        {
            yield return obj;
        }
    }

    /// <summary>
    /// GetEnumerator method
    /// </summary>
    /// <returns>IEnumerator</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}