using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Explode), 2);
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(0,5);
    }

    void Explode()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMovement enemy = collision.GetComponent<EnemyMovement>();
        enemy.GetHurt();
        Explode();
    }
}
