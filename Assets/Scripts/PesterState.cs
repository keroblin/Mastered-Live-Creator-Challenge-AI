using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesterState : State
{
    public override void StartState(Dancer dancer)
    {
        dancer.anim.Play("Panic");
        dancer.anim.enabled = false;
        dancer.agent.enabled = true;
    }
    public override void UpdateState(Dancer dancer)
    {
        if (dancer.GetDistance() > 2f)
        {
            dancer.agent.SetDestination(dancer.player.gameObject.transform.position);
        }
        else
        {
            if(dancer.gameObject.transform.position != Vector3.zero)
            {
                dancer.player.transform.SetParent(dancer.transform, true);
                dancer.agent.SetDestination(Vector3.zero);
            }
            else
            {
                dancer.CheckDanceLevel();
            }
        }
    }
    public override void ExitState(Dancer dancer)
    {
        dancer.player.transform.SetParent(null,true);
        dancer.agent.SetDestination(dancer.gameObject.transform.position);
        dancer.anim.enabled = true;
        dancer.agent.enabled = false;
    }
}
