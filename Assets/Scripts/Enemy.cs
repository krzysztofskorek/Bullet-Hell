using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float startBombingTime, interval = 2;
    public GameObject explosionPrefab;
    public int hp = 5;
    private bool isBeingDamaged;
    private const float CENTER = -4.5f;
    private SpriteRenderer sr;
    private float x, y;
    public float speed = 1;
    private float direction;
    Rigidbody2D rb;
    EnemyBehaviour eb;
    
    Func<Vector2, Vector2> pathfuncPointer;
    Action BombFuncPointer;
    
    public BulletBehaviours bb;
    private bool canStart;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();



        
        Invoke(nameof(Explode), 20.0f);
        direction = transform.position.x > CENTER ? -1 : 1; // change direction depending on the side it spawned.
        
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(StartBombing), startBombingTime, interval);
    }

    public void FixedUpdate()
    {
        if (pathfuncPointer == null) return;
        Vector2 move = pathfuncPointer(transform.position);



        rb.transform.position = move;



    }


    private void StartBombing()
    {
        if(BombFuncPointer != null)
            BombFuncPointer.Invoke();
    }



    public void GetHurt()
    {

        hp--;
        if (hp < 0)
            Explode();
        if (!isBeingDamaged)
        {
            StartCoroutine(Hurting());
        }
    }



    private void Explode()
    {
        GameObject circle = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        circle.transform.Rotate(0, 0, UnityEngine.Random.Range(-90f, 91f));
        Destroy(gameObject);
    }

    IEnumerator Hurting()
    {
        isBeingDamaged = true;
        Color oldcolor = sr.color;
        sr.color = new Color(1, 1, 1, 0.3f);
        yield return new WaitForSeconds(0.2f);
        sr.color = oldcolor;
        isBeingDamaged = false;
    }


    public void SetBehaviour(Func<Vector2, Vector2> xd)
    {
        pathfuncPointer = xd;

    }

    public void SetBombing(Action xd)
    {
        BombFuncPointer = xd;


    }




}
