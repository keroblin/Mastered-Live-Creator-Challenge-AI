using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformState : State
{
    public override void StartState(Dancer dancer)
    {
        dancer.anim.Play("Dance");
    }
    public override void UpdateState(Dancer dancer)
    {

    }
    public override void LookedAt(Dancer dancer)
    {

    }
    public override void LookedAwayFrom(Dancer dancer)
    {
        dancer.SwitchState(dancer.shy);
    }
    public override void ExitState(Dancer dancer)
    {

    }
}
