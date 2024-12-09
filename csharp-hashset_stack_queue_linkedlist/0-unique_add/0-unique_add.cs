using System;
using System.Collections.Generic;

class List {
    public static int Sum(List<int> myList) {
        HashSet<int> uniqNums = new HashSet<int>();

        for (int i = 0; i < myList.Count(); i++) {
            uniqNums.Add(myList[i]);
        }
        
        int sum = 0;
        foreach (int num in uniqNums) {
            sum += num;
        }

        return sum;
    }
}