using System;
using System.Collections.Generic;

class Dictionary {
    public static string BestScore(Dictionary<string, int> myList) {
        if (myList.Count == 0) {
            return "None";
        }

        string result = "";
        int topScore = 0;

        foreach (KeyValuePair<string, int> kvp in myList) {
            if (topScore <= kvp.Value) {
                result = kvp.Key;
                topScore = kvp.Value;
            }
        }
        return result;
    }
}