using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RegularSwap : ISwapBehaviour
{
    public bool CanSwap()
    {
        return true;
    }

    public void SwapTo(Transform transform, Vector2 position)
    {
        // depending on the direction, move object with doTween
        transform.DOMove(position, .2f).SetEase(Ease.OutCirc);
        //transform.position = position;
    }
}
