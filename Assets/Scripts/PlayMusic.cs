using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayMusic : MonoBehaviour
{
    private void Start()
    { 
       SoundManager.Instance.PlayeSound("MainTheme", true);
       SoundManager.Instance.PlayeSound("Cigarras", true);
    }
}
