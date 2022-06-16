using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Radio : ElectricalDevice
{
    public Radio(bool isOn, string brand) : base(isOn, brand)
    {

    }
    public void ListenRadio()
    {
        if (IsOn)
        {
            Debug.Log("Listening to the radio");
        }
        else
        {
            Debug.Log("Radio is switched off, switch on to liste");
        }
    }
}
