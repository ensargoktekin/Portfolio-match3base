using RoyalKingdom.Block;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace RoyalKingdom.Factory
{
    public class BlockFactory : MonoBehaviour
    {
        #region variables
        public static BlockFactory Inst => _instance;
        private static BlockFactory _instance;

        [SerializeField] private Transform _blockParent;
        [SerializeField] private SimpleBlock _simpleBlockRedPrefab;
        [SerializeField] private SimpleBlock _simpleBlockGreenPrefab;
        [SerializeField] private SimpleBlock _simpleBlockBluePrefab;
        [SerializeField] private SimpleBlock _simpleBlockYellowPrefab;
        [SerializeField] private Rocket _horizontalRocketPrefab;
        [SerializeField] private Rocket _verticalRocketPrefab;
        [SerializeField] private Wood _woodPrefab;
        [SerializeField] private TeddyBear _teddyBearPrefab;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            // singleton
            if (_instance)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
            }
        }
        #endregion

        #region Block Creation
        public BaseBlock MakeBlock(BlockMakeParams blockMakeParams)
        {
            if (blockMakeParams.BlockType == BlockMakeType.None)
                return null;
            return CreateNewBlock(blockMakeParams);
        }

        private BaseBlock CreateNewBlock(BlockMakeParams blockMakeParams)
        {
            Assert.AreNotEqual(BlockMakeType.None, blockMakeParams.BlockType);
            BaseBlock prefab = blockMakeParams.BlockType switch
            {
                BlockMakeType.Simple => GetPrefab(blockMakeParams.SubType.SimpleBlockType),
                BlockMakeType.Rocket => GetPrefab(blockMakeParams.SubType.RocketType),
                BlockMakeType.Wood => GetPrefab(blockMakeParams.SubType.WoodType),
                BlockMakeType.TeddyBear => GetPrefab(blockMakeParams.SubType.TeddyBearType),
                _ => throw new System.NotImplementedException()
            };

            BaseBlock block;
            if (prefab != null)
            {
                block = Instantiate(prefab);
                block.transform.SetParent(_blockParent);
            }
            else
            {
                return null;
            }

            return block;
        }
        #endregion

        #region Getting prefabs
        private BaseBlock GetPrefab(SimpleBlock.Type type)
        {
            switch (type)
            {
                case SimpleBlock.Type.Red:
                    return _simpleBlockRedPrefab;
                case SimpleBlock.Type.Green:
                    return _simpleBlockGreenPrefab;
                case SimpleBlock.Type.Blue:
                    return _simpleBlockBluePrefab;
                case SimpleBlock.Type.Yellow:
                    return _simpleBlockYellowPrefab;
                default:
                    throw new System.NotImplementedException();
            }
        }

        private BaseBlock GetPrefab(Rocket.Type type)
        {
            switch (type)
            {
                case Rocket.Type.Horizontal:
                    return _horizontalRocketPrefab;
                case Rocket.Type.Vertical:
                    return _verticalRocketPrefab;
                default:
                    throw new System.NotImplementedException();
            }
        }

        private BaseBlock GetPrefab(Wood.Type type)
        {
            switch (type)
            {
                case Wood.Type.RegularWood:
                    return _woodPrefab;
                default:
                    throw new System.NotImplementedException();
            }
        }

        private BaseBlock GetPrefab(TeddyBear.Type type)
        {
            switch (type)
            {
                case TeddyBear.Type.RegularTeddyBear:
                    return _teddyBearPrefab;
                default:
                    throw new System.NotImplementedException();
            }
        }
        #endregion
    }
}
