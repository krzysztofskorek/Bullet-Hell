using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] string functionName;

    //public items
    public GameObject charm;
    public Transform shootingPoint; // point from where the player shoots.
    public SpriteRenderer HitBall;

    // public variables
    public float Maxspeed = 5.0f;

     

    // initialized at the start
    PlayerInputs inputActions;
    Rigidbody2D rigidbody2;
    SpriteRenderer spriteRenderer;
    
    //private variables
    private EnemyBehaviour enemyBehaviour;
    private bool canShoot;
    private float currSpeed;
    Color defaultColor;

    private Vector2 movement;
    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new PlayerInputs();

        rigidbody2 = GetComponent<Rigidbody2D>();

        currSpeed = Maxspeed;

        spriteRenderer = GetComponent<SpriteRenderer>();

        var type = Type.GetType(functionName);  
        enemyBehaviour = (EnemyBehaviour)Activator.CreateInstance(type);

        defaultColor = spriteRenderer.color;
    }

    

    private void OnEnable()
    {
        
        inputActions.Player.Enable();
        inputActions.Player.Fire.performed += OnFire;
        inputActions.Player.Fire.canceled += OnStopFiring;
        inputActions.Player.Focus.performed += OnFocus;
        inputActions.Player.Focus.canceled += OnBlur;
        

    }

    private void OnDisable()
    {
        
        inputActions.Player.Fire.performed -= OnFire;
        inputActions.Player.Fire.canceled -= OnStopFiring;
        inputActions.Player.Focus.performed -= OnFocus;
        inputActions.Player.Focus.canceled -= OnBlur;
        inputActions.Player.Disable();
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        canShoot = true;
        StartCoroutine(ShootingCoroutine());
    }

    public void OnStopFiring(InputAction.CallbackContext ctx) { 
        canShoot= false;
    }


    private void Update()
    {
        movement = inputActions.Player.Move.ReadValue<Vector2>();
        rigidbody2.velocity = movement * currSpeed;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.OnPlayerHasLost();
    }


    public void OnFocus(InputAction.CallbackContext ctx)
    {
        currSpeed = Maxspeed / 2;
        spriteRenderer.color = new Color(1, 0.5f, 0.1f);
        Color temp = HitBall.color;
        temp.a = 1.0f;
        HitBall.color = temp;
    }

    public void OnBlur(InputAction.CallbackContext ctx) {
        currSpeed = Maxspeed;
        spriteRenderer.color = defaultColor;
        Color temp = HitBall.color;
        temp.a = 0.0f;
        HitBall.color = temp;
    }

    public void OnBomb(InputAction.CallbackContext ctx)
    {
        
    }


    IEnumerator ShootingCoroutine()
    {
        float interval = 0.1f;
        while (canShoot) {
            Instantiate(charm,shootingPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
        
    }
}
