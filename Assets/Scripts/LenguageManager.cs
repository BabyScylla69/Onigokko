using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenguageManager : MonoBehaviour
{
    private static LenguageManager _instance;
    public static LenguageManager instance => _instance;

    public delegate void changeText();
    public static changeText change;

    private int lan;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        lan = 0;
    }
    public void ChangeLang()
    {
        LocalisationSystem.instance.swaplan(lan);
        change();
    }

    public void ChangeLan(int i)
    {
        lan = i;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeLang();
    }
}
