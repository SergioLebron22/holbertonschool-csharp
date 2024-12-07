using System;
using System.Collections.Generic;
using System.Linq;

class Dictionary {
    public static void PrintSorted(Dictionary<string, string> myDict) {
        var sortedByKey = myDict.OrderBy(kvp => kvp.Key);

        foreach (var kvp in sortedByKey) {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}