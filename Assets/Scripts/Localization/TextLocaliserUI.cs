using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliserUI : MonoBehaviour
{
    TextMeshProUGUI textField;

    public string key;

    private void OnEnable()
    {
        LenguageManager.change += ChangeLang;
    }
    private void OnDisable()
    {
        LenguageManager.change -= ChangeLang;
    }
    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        string value = LocalisationSystem.instance.GetLocalisedValue(key);
        textField.text = value;
    }

    public void ChangeKey(string k)
    {
        key = k;
    }

   void ChangeLang()
    {
        textField = GetComponent<TextMeshProUGUI>();
        string value = LocalisationSystem.instance.GetLocalisedValue(key);
        textField.text = value;
    }
}
