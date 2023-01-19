using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationSystem : MonoBehaviour
{
    private static LocalisationSystem _instance;
    public static LocalisationSystem instance => _instance;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
    }

    public enum Language
    {
        Spanish,
        English
    }

    public Language language = Language.Spanish;

    private static Dictionary<string, string> localisedES;
    private static Dictionary<string, string> localisedEN;

    public static bool isInit;

    private int lan;
    private Language savedLanguage;

    public void returnlan()
    {
        Debug.Log(lan);
    }

    public void ChangeLanguage()
    {
        if (lan == 0)
        {
            language = Language.Spanish;
        }
        if (lan == 1)
        {
            language = Language.English;
        }
    }

    public void swaplan(int i)
    {
        lan = i;
        ChangeLanguage();
    }

    public void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedES = csvLoader.GetDictionaryValues("es");
        localisedEN = csvLoader.GetDictionaryValues("en");

        isInit = true;
    }

    public string GetLocalisedValue(string key)
    {
        if(!isInit) { Init(); }

        string value = key;

        switch(language)
        {
            case Language.Spanish:
                localisedES.TryGetValue(key, out value);
                break;
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                break;
        }

        return value;
    }
}
