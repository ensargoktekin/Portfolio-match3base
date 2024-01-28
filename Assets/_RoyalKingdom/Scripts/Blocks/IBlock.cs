using UnityEngine;

public interface IBlock
{
    void SwapTo(Vector2 position); // check necessary conditions in grid controller
    void Fall(double height); // check necessary conditions in grid controller
    void Pop(); // when object is destroyed, some animations are needed
    void NeighbourPop(); // called when neighbour is popped, necessary for boxes
}
