using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using TMPro;

[CreateAssetMenu(menuName = "FSM/Carnation/Dialogues")]
public class DialoguesSpawn : Action
{
    public string key;
    private DialoguesBehaviour dialogue;
    private TextMeshProUGUI text;
    bool did = false;
    public override void Act(Controller controller)
    {
        text = GameManager.instance.returnText();
        text.GetComponent<TextLocaliserUI>().ChangeKey(key);
        dialogue = GameManager.instance.returnDialogueBehaviour();
        dialogue.GetText(text);
        GameManager.instance.ActivateText();

    }
}
