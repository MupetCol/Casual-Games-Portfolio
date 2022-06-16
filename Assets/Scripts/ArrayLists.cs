using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ArrayLists : MonoBehaviour
{
    ArrayList arrList = new ArrayList{12,34,56};
    void Start()
    {
        arrList.Add(25);
        arrList.Add(12.34);
        arrList.Add("Hello list");
        arrList.Add('a');
        arrList.Add(3.434242351);

        //delete element with specific value from arraylist
        arrList.Remove(25);
        arrList.Remove(25);
        arrList.Remove(25);

        //delete element on specific position
        arrList.RemoveAt(arrList.Count-1);

        Debug.Log(arrList.Count);

        double sum = 0;

        foreach(object ob in arrList)
        {
            if(ob is int)
            {
                sum+= Convert.ToDouble(ob);
            }else if(ob is double)
            {
                sum += (double)ob;
            }else if (ob is string)
            {
                Debug.Log(ob.ToString());
            }
        }

        Debug.Log (sum);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
