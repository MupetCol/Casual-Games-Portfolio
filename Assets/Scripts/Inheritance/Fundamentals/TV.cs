using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TV : ElectricalDevice
{
    public TV(bool isOn, string brand) : base(isOn, brand)
    {

    }
    public void WatchTV()
    {
        if (IsOn)
        {
            Debug.Log("Watching TV");
        }
        else
        {
            Debug.Log("TV is off");
        }
    }
}
