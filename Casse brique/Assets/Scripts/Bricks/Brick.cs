using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick
{
    public int pv;
    public int points;

    public Brick()
    {
        pv = 1;
        points = 10;
    }

    public Brick(int pv):this()
    {
        this.pv = pv;
    }

    public Brick(int pv, int points):this(pv)
    {
        this.points = points;
    }
}
