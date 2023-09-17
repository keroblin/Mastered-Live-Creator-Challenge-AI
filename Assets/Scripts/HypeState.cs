using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypeState : State
{
    public override void StartState(Dancer dancer)
    {
        dancer.anim.Play("Hype");
    }
    public override void UpdateState(Dancer dancer)
    {
        if (!dancer.CheckLook() || dancer.GetDistance() > dancer.confidenceDistance)
        {
            dancer.CheckDanceLevel();
        }
    }

    public override void ExitState(Dancer dancer)
    {

    }
}
