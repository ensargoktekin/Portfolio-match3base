using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSwap : ISwapBehaviour
{
    public bool CanSwap()
    {
        return false;
    }

    public void SwapTo(Transform transform, Vector2 position)
    {
        // no swap
    }
}
