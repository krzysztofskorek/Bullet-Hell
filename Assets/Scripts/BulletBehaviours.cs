using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviours 
{
    public  string leav = "Leaf";

    private Transform trans;

    private GameObject player;

    public BulletBehaviours(Transform trans) {
        this.trans = trans;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("cannot find player object");
        }
         
    }
   public virtual void Behaviour()
    {
        
        GameObject leaf = Resources.Load<GameObject>(leav);
        GameObject.Instantiate(leaf, trans.position, Quaternion.identity);
        Bullet bulletScript = leaf.GetComponent<Bullet>();
        bulletScript.target = player;
        bulletScript.isHoming = true;

    }


}


public class Garrote : BulletBehaviours
{
    public Garrote(Transform trans) : base(trans)
    {
    }

    public override void Behaviour() { 
    
    
    }
}

