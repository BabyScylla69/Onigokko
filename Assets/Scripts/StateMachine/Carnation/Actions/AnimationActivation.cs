using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Carnation/AnimationActivation")]
public class AnimationActivation : Action
{
    bool did = false;
    public Animator _anim;
    public override void Act(Controller controller)
    {
        if(!did)
            //_anim.SetInteger("State", 1);
        did = true;
    }
}
