using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave 
{
    Func<Rigidbody2D, Vector2> movementPath;
    public Wave(Func<Rigidbody2D, Vector2> xd)
    {
        movementPath = xd;
    }
}
