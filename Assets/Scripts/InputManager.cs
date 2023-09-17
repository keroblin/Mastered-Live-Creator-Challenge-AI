using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    PlayerControls controls;
    PlayerControls.DefaultActions actions;

    Vector2 playerMove;
    private void Awake()
    {
        controls = new PlayerControls();
        actions = controls.Default;

        actions.Move.performed += ctx => playerMove = ctx.ReadValue<Vector2>();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        controller.ReceiveInput(playerMove);
    }
}
