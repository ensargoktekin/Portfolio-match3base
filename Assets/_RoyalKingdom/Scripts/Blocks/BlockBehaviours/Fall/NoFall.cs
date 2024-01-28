using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFall : IFallBehaviour
{
    public bool CanFall()
    {
        return false;
    }

    public void Fall(double height)
    {
        // No Movement
        Debug.Log("No Movement");
    }
}
