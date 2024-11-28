using UnityEngine;





 
public  class EnemyBehaviour 
{

    public float x;
    public float y;
    public float direction;


    public virtual void Init(float dir)
    {
        direction = dir;
    }



    public virtual Vector2 Behaviour(Vector2 xd)
    {
        Vector3 destination = direction == -1 ? Positions.SpitRoastRight : Positions.SpitRoastLeft;
        Vector2 newPos = Vector2.MoveTowards(xd, destination, 2 * Time.fixedDeltaTime);
        return newPos;

    }

}




public class Test :EnemyBehaviour
{
    public override Vector2 Behaviour(Vector2 xy)
    {
        throw new System.NotImplementedException();
    }

    public override void Init(float dir)
    {
        throw new System.NotImplementedException();
    }
}