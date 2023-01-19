using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FSM;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance => _instance;

    [SerializeField] 
    private GameObject text;
    [SerializeField]
    private TextMeshProUGUI _textInside;

    public DialoguesBehaviour _dialogues;
    public State currentStateInt;

    Controller controller;


    private void Awake()
    {
        _instance = this;
        controller = GetComponent<Controller>();
        SoundManager.Instance.PlayeSound("MainGame", true);
        SoundManager.Instance.PlayeSound("Nana", true);
    }
    public void ActivateText()
    {
        text.SetActive(true);
    }
    public void DeactivateText()
    {
        text.SetActive(false);
    }

    public TextMeshProUGUI returnText()
    {
        return _textInside;
    }

    public DialoguesBehaviour returnDialogueBehaviour()
    {
        return _dialogues;
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.SetState(currentStateInt);
        }
        */
    }
}
