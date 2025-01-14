using System;

/// <summary>
/// Obj class
/// </summary>
class Obj {
    /// <summary>
    /// A method that checks if the object passed is int
    /// </summary>
    /// <returns>true if obj is int, else false</returns>
    public static bool IsOfTypeInt(object obj) {
        if (obj is int) return true;
        return false;
    }
}