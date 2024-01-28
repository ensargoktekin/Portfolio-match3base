using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDamagedByNeighbourPop : INeighbourPopBehaviour
{
    public void NeighbourPop(System.Action damage)
    {
        // no action is taken by neighbour pop
    }
}
