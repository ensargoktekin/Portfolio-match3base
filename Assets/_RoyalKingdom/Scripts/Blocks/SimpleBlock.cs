using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoyalKingdom.Block
{
    public class SimpleBlock : BaseBlock
    {
        [SerializeField] private Type _type;

        public enum Type
        {
            None,
            Red,
            Green,
            Blue,
            Yellow
        }

        //public Type SimpleBlockType => _type;

        private void Start()
        {
            _swapBehaviour = new RegularSwap();
        }

        #region Abstract Methods
        public override void Fall(double height)
        {
            _fallBehaviour.Fall(height);
        }

        public override void NeighbourPop()
        {
            _neighbourPopBehaviour.NeighbourPop(()=>{ });
        }

        public override void Pop()
        {
            _popBehaviour.Pop();
        }

        public override void SwapTo(Vector2 position)
        {
            _swapBehaviour.SwapTo(transform, position);
        }
        #endregion
    }
}
