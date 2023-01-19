using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Carnation/DecisionSwap")]
public class DecisionSwap : Decision
{
    private DialoguesBehaviour dialogue;
    public override bool Decide(Controller controller)
    { 
        if (GameManager.instance.returnDialogueBehaviour().TextFinished())
        {
            GameManager.instance.returnDialogueBehaviour().RestartText();
            return true;
        }

        return false;
      
    }
}
