﻿using System;
using System.Collections.Generic;

class Dictionary {
    public static Dictionary<string, string> AddKeyValue(Dictionary<string, string> myDict, string key, string value) {
        if (myDict.ContainsKey(key) == true) {
            myDict[key] = value;
            return myDict;
        }
        myDict.Add(key, value);
        return myDict;
    }
}