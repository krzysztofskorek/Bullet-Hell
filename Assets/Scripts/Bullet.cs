using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector2 Velocity = new Vector2(0, -5);
    public Rigidbody2D rb;
    protected Vector3 newVelocity;
    protected float speed = 5.0f;
    public GameObject target;
    public bool isHoming;

    protected virtual IEnumerator Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(Explode), 2);
        rb.velocity = new Vector2(0, -5);
        yield return new WaitForFixedUpdate();
        if (isHoming)
            StartCoroutine(nameof(FollowPlayer));


    }

    private void FixedUpdate()
    {

        //rb.MovePosition(transform.position + (newVelocity * Time.fixedDeltaTime));
    }



    IEnumerator FollowPlayer()
    {
        newVelocity = target.transform.position - transform.position;
        float counter = 0;
        while (counter < 2f)
        {
            counter += Time.fixedDeltaTime;
            rb.MovePosition(transform.position + (newVelocity * Time.fixedDeltaTime));
            yield return new WaitForFixedUpdate();
        }

    }
    protected void Explode()
    {

        Destroy(gameObject);
    }

    public void SetVelocity(Vector2 newVel)
    {
        Velocity = newVel;
    }


}
