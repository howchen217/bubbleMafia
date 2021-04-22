using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class MoveInputEvent : UnityEvent<Vector2> { }


public class InputController : MonoBehaviour
{
    private Inputs inputs;
    //this adding subscriber thing is quite uselss cus I still need to manually assign objects to it..
    [SerializeField] private MoveInputEvent moveInputEvent;

    private void Awake()
    {
        inputs = new Inputs();
    }

    private void OnEnable()
    {
        inputs.Player.Enable();
    }

    private void OnDisable()
    {
        inputs.Player.Disable();
    }


    private void FixedUpdate()
    {
        //moveInputEvent.Invoke(inputs.Player.Movement.ReadValue<Vector2>()); //invoke for all subscribers
    }

}
