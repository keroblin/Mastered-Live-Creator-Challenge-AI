using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShyState : State
{
    public override void StartState(Dancer dancer)
    {
        dancer.anim.Play("Downtrodden");
    }
    public override void UpdateState(Dancer dancer)
    {
        if (dancer.GetPlayerDirection() > 0.2)
        {
            dancer.CheckDanceLevel();
        }
    }
    public override void ExitState(Dancer dancer)
    {

    }
}
