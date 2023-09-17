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
    public GameObject player;
    public Collider col;
    public RaycastHit hit;


    void Start()
    {
        SwitchState(perform);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        //might do look at functionality here, might not

        //might do dot product here instead?
        int layerMask = 1 << 6;

        if (Physics.Raycast(player.transform.position, player.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,layerMask))
        {
            if(hit.collider == col)
            {
                Debug.DrawRay(player.transform.position, player.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Looking at");
                currentState.LookedAt(this);
            }
            else
            {
                Debug.DrawRay(player.transform.position, player.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Looking away");
                currentState.LookedAwayFrom(this);
            }
        }
        else
        {
            Debug.DrawRay(player.transform.position, player.transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("Looking away");
            currentState.LookedAwayFrom(this);
        }
    }

    public void SwitchState(State state)
    {
        Debug.Log("State switched to " + state);
        if(currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = state;
        currentState.StartState(this);
    }
}
