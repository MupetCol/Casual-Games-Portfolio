using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class ResolutionSettings : MonoBehaviour
{
    private void Start()
    {
        SetResolution();
    }

    public void SetResolution()
    {
        Screen.SetResolution(1920,1080,Screen.fullScreen = false);
    }
}
