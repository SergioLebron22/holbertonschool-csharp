using System;

/// <summary>
/// This is a queue class with generic type
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T> 
{
    /// <summary>
    /// returns the type of the queue
    /// </summary>
    /// <returns>type of T</returns>
    public Type CheckType() {
        return typeof(T);
    }    
}