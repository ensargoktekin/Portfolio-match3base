using RoyalKingdom.Block;
using RoyalKingdom.Factory;
using RoyalKingdom.InputSystem;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace Grid
{
    public class Grid : MonoBehaviour, IGrid
    {
        [SerializeField] private List<Slot> _slots; // Size = 9x10
        private int _sizeX = 9, _sizeY = 10;
        private BlockType[,] _blockTypeMap;

        private enum BlockType
        {
            None,
            SimpleGreen,
            SimpleBlue,
            SimpleRed,
            SimpleYellow,
        }

        private void OnEnable()
        {
            InputController.UserSwappedObject += UserSwappedObjectHandler;
        }

        private void OnDisable()
        {
            InputController.UserSwappedObject -= UserSwappedObjectHandler;
        }

        private void Awake()
        {
            //_blockTypeMap = new BlockType[_sizeY,_sizeX];
            //for (int i = 0; i < _sizeY; i++)
            //{
            //    for (int j = 0; j < _sizeX; j++)
            //    {
            //        _blockTypeMap[i,j] = _slots[i * _sizeX + j];
            //    }
            //}
        }

        public void FallColumn(int columnId, int step)
        {
            throw new System.NotImplementedException();
        }

        public void InitializeGrid(List<BlockMakeParams> blockMakeParams)
        {
            //_slots = new List<Slot>(); // 9x10 grid
            BlockFactory blockFactory = BlockFactory.Inst;
            for (int i = 0; i < 90; i++)
            {
                _slots[i].LocateInitialBlock(blockFactory.MakeBlock(blockMakeParams[i]));
            }

        }

        public void SwapObjects(Slot slot1, Slot slot2)
        {
            BaseBlock block1 = slot1.ReleaseBlock();
            BaseBlock block2 = slot2.ReleaseBlock();

            slot1.AnimateSwapNewBlock(block2);
            slot2.AnimateSwapNewBlock(block1);

        }

        #region Listeners
        private void UserSwappedObjectHandler(Slot slot, RoyalKingdom.InputSystem.InputController.SwapDirection swapDirection)
        {
            int idx = _slots.IndexOf(slot);

            if (!CheckMovementInGrid(idx, swapDirection))
                return;

            int changeNum = 0;
            switch(swapDirection)
            {
                case InputController.SwapDirection.Left:
                    changeNum = -1;
                    break;
                case InputController.SwapDirection.Right:
                    changeNum = 1;
                    break;
                case InputController.SwapDirection.Up:
                    changeNum = -_sizeX;
                    break;
                case InputController.SwapDirection.Down:
                    changeNum = +_sizeX;
                    break;
                default:
                    break;
            }

            if (CheckObjectsCanSwap(slot, _slots[idx + changeNum]))
            { 
                SwapObjects(slot, _slots[idx+changeNum]);
            }
        }
        #endregion

        #region Helpers
        private bool CheckMovementInGrid(int idx, InputController.SwapDirection swapDirection)
        {
            // checking left edge
            if (idx % _sizeX == 0 && swapDirection == InputController.SwapDirection.Left)
                return false;

            // checking right edge
            if (idx % _sizeX == _sizeX - 1 && swapDirection == InputController.SwapDirection.Right)
                return false;

            // checking up edge
            if (idx / _sizeY == 0 && swapDirection == InputController.SwapDirection.Up)
                return false;

            // checking down edge
            if (idx / _sizeY == _sizeY - 1 && swapDirection == InputController.SwapDirection.Down)
                return false;

            return true;
        }

        private bool CheckObjectsCanSwap(Slot slot1, Slot slot2)
        {
            return slot1.CanSwap && slot2.CanSwap;
        }
        #endregion
    }
}
