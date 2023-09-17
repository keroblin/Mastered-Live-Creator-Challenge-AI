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
        
    }
    public override void LookedAt(Dancer dancer)
    {
        dancer.SwitchState(dancer.perform);
    }
    public override void LookedAwayFrom(Dancer dancer)
    {

    }
    public override void ExitState(Dancer dancer)
    {

    }
}
