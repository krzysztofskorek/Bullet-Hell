using UnityEngine;

public class EnemyBehaviours
{

    private float x, y;
    private float direction;


    public void Init(float dir)
    {

        direction = dir;
    }


    public Vector2 Behaviour(Vector2 xd)
    {
        Vector3 destination = direction == -1 ? Positions.SpitRoastRight : Positions.SpitRoastLeft;
        Vector2 newPos = Vector2.MoveTowards(xd, destination, 2 * Time.fixedDeltaTime);
        return newPos;
    }
}







