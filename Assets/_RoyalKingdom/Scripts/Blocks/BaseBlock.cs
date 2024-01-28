using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoyalKingdom.Block
{
    public abstract class BaseBlock : MonoBehaviour, IBlock
    {
        #region Variables/Attributes
        // Behaviours
        protected ISwapBehaviour _swapBehaviour;
        protected IFallBehaviour _fallBehaviour;
        protected IPopBehaviour _popBehaviour;
        protected INeighbourPopBehaviour _neighbourPopBehaviour;

        // other variables
        //private double _height; // Height of the current cell. Used to fall object in proper size

        public bool CanSwap => _swapBehaviour.CanSwap();
        public bool CanFall => _fallBehaviour.CanFall();
        #endregion

        #region abstract methods
        public abstract void SwapTo(Vector2 position);

        public abstract void Fall(double height);

        public abstract void Pop();

        public abstract void NeighbourPop();
        #endregion
    }
}

