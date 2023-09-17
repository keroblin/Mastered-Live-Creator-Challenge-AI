using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesterState : State
{
    public override void StartState(Dancer dancer)
    {
        dancer.anim.Play("Panic");
    }
    public override void UpdateState(Dancer dancer)
    {
        if (dancer.GetDistance() > dancer.confidenceDistance)
        {
            dancer.agent.SetDestination(dancer.gameObject.transform.position);
        }
        else
        {
            dancer.CheckDanceLevel();
        }
    }
    public override void ExitState(Dancer dancer)
    {
        dancer.agent.SetDestination(dancer.gameObject.transform.position);
    }
}
