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
        if (dancer.GetDistance() > 4f)
        {
            dancer.agent.SetDestination(dancer.player.gameObject.transform.position);
        }
        else
        {
            if (Vector3.Distance(dancer.gameObject.transform.position, Vector3.zero) > 1.5f)
            {
                dancer.player.transform.SetParent(dancer.transform, true);
                dancer.col.enabled = false;
                dancer.agent.SetDestination(Vector3.zero);
                Debug.Log("Heading to zero");
            }
            else
            {
                dancer.CheckDanceLevel();
            }
        }
    }
    public override void ExitState(Dancer dancer)
    {
        dancer.col.enabled = true;
        dancer.player.transform.SetParent(null,true);
        dancer.agent.SetDestination(dancer.gameObject.transform.position);
        dancer.anim.enabled = true;
        dancer.agent.enabled = false;
    }
}
