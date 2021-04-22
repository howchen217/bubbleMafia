using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f; 
    public Animator ani;

    private Inputs inputs;

    public static PlayerController instance { get; private set; }

    public String areaTransitionName;

    private void Awake()
    {
        CheckInstance();//avoid duplicates

        inputs = new Inputs();
        DontDestroyOnLoad(gameObject); //not destroyed by default. 
    }

    private void OnEnable()
    {
        inputs.Player.Movement.Enable();
    }


    void FixedUpdate()
    {
        OnMoveInput(inputs.Player.Movement.ReadValue<Vector2>());
    }


    public void OnMoveInput(Vector2 direction) {
        rb.velocity = direction * moveSpeed;

        ani.SetFloat("moveX", rb.velocity.x);
        ani.SetFloat("moveY", rb.velocity.y);

        if (direction.x != 0 || direction.y != 0)
        {
            ani.SetFloat("lastMoveX", direction.x);
            ani.SetFloat("lastMoveY", direction.y);
        }
    }

    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public static void Freeze() 
    {
        instance.rb.simulated = false;
    }

    public static void UnFreeze()
    {
        instance.rb.simulated = true;
    }

}
