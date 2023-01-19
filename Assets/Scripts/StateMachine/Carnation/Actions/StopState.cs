using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FSM;

[CreateAssetMenu(menuName = "FSM/Carnation/StopState")]
public class StopState : Action
{
    public override void Act(Controller controller)
    {
        ///quitas la UI
        GameManager.instance.gameObject.GetComponent<Controller>().currentState = null;
    }
}
