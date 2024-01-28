using UnityEngine;

public interface ISwapBehaviour
{
    void SwapTo(Transform transform, Vector2 position);
    bool CanSwap();
}
