using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dancer : MonoBehaviour
{
    public State currentState;
    public HypeState hype = new HypeState();
    public ShyState shy = new ShyState();
    public PesterState pester = new PesterState();
    public PerformState perform = new PerformState();

    public float confidenceDistance = 30f;
    public NavMeshAgent agent;
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
    }

    public void SwitchState(State state)
    {
        if(state != currentState)
        {
            Debug.Log("State switched to " + state);
            if (currentState != null)
            {
                currentState.ExitState(this);
            }
            currentState = state;
            currentState.StartState(this);
        }
    }

    public bool CheckLook()
    {
        if (Physics.Raycast(player.transform.position, player.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider == col)
            {
                Debug.DrawRay(player.transform.position, player.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public float GetDistance()
    {
        return Vector3.Distance(gameObject.transform.position, player.transform.position);
    }

    public float GetPlayerDirection()
    {
        Vector3 dir = (transform.position - player.transform.position).normalized;
        float direction = Vector3.Dot(dir, player.transform.forward);
        return direction;
    }

    public void CheckDanceLevel()
    {
        float dir = GetPlayerDirection();
        if (GetDistance() < confidenceDistance && dir > .8f)
        {
            if (CheckLook())
            {
                SwitchState(hype);
                return;
            }
            
            if(dir > 0.9)
            {
                SwitchState(perform);
                return;
            }
            else if(dir > 0.8)
            {
                SwitchState(shy);
                return;
            }
        }
        else if(GetDistance() > confidenceDistance && dir < .8f)
        {
            SwitchState(pester);
        }
    }
}
