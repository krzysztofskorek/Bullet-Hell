using UnityEngine;

public static class Positions
{
    public static Vector3 TopLTopLeftCorner = new Vector3(-9,5,0);
    public static Vector3 TopRightCorner = new Vector3(0, 5, 0);
     


    public static Vector3 curtainLeft = new(-9, 5, 0);
    public static Vector3 curtainRight = new(0, 5, 0);
    public static Vector3 CenterLeft = new(-10, 0, 0);
    public static Vector3 CenterRight = new(0, 0, 0);
    public static Vector3 SpitRoastLeft = new(-7, -0.5f, 0);
    public static Vector3 SpitRoastRight = new(-2, -0.5f, 0);



    public static Vector3 GetCurtain(bool ToRight)
    {
        if (ToRight)
            return curtainRight;
        else
            return curtainLeft;
    }

    public static Vector3 GetCenter(bool ToRight)
    {
        if (ToRight)
            return CenterRight;
        else
            return CenterLeft;
    }

    public static Vector3 GetSpitRoast(bool ToRight)
    {
        if (ToRight)
            return SpitRoastRight;
        else
            return SpitRoastLeft;
    }
}
