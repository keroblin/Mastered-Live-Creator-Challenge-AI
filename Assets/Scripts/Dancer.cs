using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public State currentState;
    public HypeState hype = new HypeState();
    public ShyState shy = new ShyState();
    public PesterState pester = new PesterState();
    public PerformState perform = new PerformState();

    public Animator anim;

    void Start()
    {
        SwitchState(perform);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        //might do look at functionality here, might not
    }

    public void SwitchState(State state)
    {
        if(currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = state;
        currentState.StartState(this);
    }
}
