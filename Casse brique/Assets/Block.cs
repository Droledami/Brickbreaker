using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    public int pv;

    public Block()
    {
        pv = 1;
    }

    public Block(int pv)
    {
        this.pv = pv;
    }
}
