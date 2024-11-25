using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private float transTime = 0.2f;
    private float timePassed;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke(nameof(Yeet), 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 5,0), Time.fixedDeltaTime * 10);
        timePassed = Time.fixedDeltaTime;
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(spriteRenderer.color.r, spriteRenderer.color.g,spriteRenderer.color.b, 0f), timePassed / transTime);
    }

    private void Yeet()
    {
        Destroy(gameObject);
    }
}
