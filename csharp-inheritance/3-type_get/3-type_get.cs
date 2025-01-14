using System;
using System.Collections.Generic;
using System.Reflection;

class Obj {
    public static void Print(object obj) {
        Type type = obj.GetType();

        Console.WriteLine($"{type.Name} Properties:");
        foreach (PropertyInfo property in type.GetProperties()) {
            Console.WriteLine(property.Name);
        }
        Console.WriteLine($"{type.Name} Methods:");
        foreach (MethodInfo method in type.GetMethods()) {
            Console.WriteLine(method.Name);
        }
    }
}