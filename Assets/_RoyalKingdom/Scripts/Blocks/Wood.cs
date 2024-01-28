using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoyalKingdom.Block
{
    public class Wood : BaseBlock
    {
        [SerializeField] private Type _type;

        public enum Type
        {
            None,
            RegularWood
        }

        //public Type WoodType => _type;

        private void Start()
        {
            _swapBehaviour = new NoSwap();
        }

        #region Abstract Methods
        public override void Fall(double height)
        {
            throw new System.NotImplementedException();
        }

        public override void NeighbourPop()
        {
            throw new System.NotImplementedException();
        }

        public override void Pop()
        {
            throw new System.NotImplementedException();
        }

        public override void SwapTo(Vector2 position)
        {
            _swapBehaviour.SwapTo(transform, position);
        }
        #endregion
    }
}
