using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamsKeyword : MonoBehaviour
{
    int[] arrNum1 = { 0, 9, -11, -29, 5, 19, 23, 23, 424 };
    void Start()
    {
        int min = Min(arrNum1);
        int min2 = Min(1, 2, 3, 4, 5, 6, 6, 7, 7);
        Debug.Log("The minimum number is: "  + min);
    }

    // Params keyword, let us input an deliberate number of parameters to a called method
    public int Min(params int[] numbers)
    {
        int min = int.MaxValue;

        foreach(int num in numbers)
        {
            if (num < min) min = num;
        }
        return min;
    }
}
