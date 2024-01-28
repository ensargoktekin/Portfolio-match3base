using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularFall : IFallBehaviour
{
    public bool CanFall()
    {
        return true;
    }

    public void Fall(double height)
    {
        // change transform of the object with doTween
    }
}
