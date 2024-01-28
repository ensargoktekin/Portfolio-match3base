using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedByNeighbourPop : INeighbourPopBehaviour
{
    public void NeighbourPop(System.Action damage)
    {
        damage?.Invoke();
    }
}
