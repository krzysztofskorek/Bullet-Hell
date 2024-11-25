using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float startBombingTime, interval =2;
    public GameObject explosionPrefab;
    public int hp = 5;
    private bool isBeingDamaged;
    private const float CENTER = -4.5f;
    private SpriteRenderer sr;
    private float x, y;
    public float speed = 1;
    private float direction;
    Rigidbody2D rb;
    EnemyBehaviours eb;
    public delegate Vector2 EnemyBehaviour(float x, float y);
    Func<Vector2, Vector2> pathfuncPointer;
    Action BombFuncPointer;
    EnemyBehaviour enemyBehaviour;
    public BulletBehaviours bb;
    private bool canStart;

    public IEnumerator Start()
    {
        sr = GetComponent<SpriteRenderer>();
        yield return new WaitUntil(czyMoznaZaczac);
        
        
        eb = new EnemyBehaviours();
        bb = new BulletBehaviours(transform);
        this.SetBehaviour(eb.Behaviour);
        this.SetBombing(bb.Behaviour);
        Invoke(nameof(Explode), 20.0f);
        direction = transform.position.x > CENTER ? -1 : 1; // change direction depending on the side it spawned.
        eb.Init(direction);
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(StartBombing), startBombingTime, interval);
    }

    public void FixedUpdate()
    {
        Vector2 move = pathfuncPointer(transform.position);
         
        

        rb.transform.position = move;
      


    }


    private void StartBombing()
    {
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


    public void SetBehaviour(Func<Vector2,  Vector2> xd)
    {
        pathfuncPointer = xd;
         
    }

    public bool SetBombing(Action  xd)
    {
        BombFuncPointer = xd;
        return true;
         
    }

    private bool czyMoznaZaczac()
    {
        canStart = true;
        return canStart;
    }


}
