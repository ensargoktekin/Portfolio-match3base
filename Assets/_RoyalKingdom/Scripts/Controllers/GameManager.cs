using RoyalKingdom.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Grid.Grid _grid;

    private void Start()
    {
        List<BlockMakeParams> blockMakeParams = new List<BlockMakeParams>();

        for (int j = 0; j < 9; j++)
        {
            BlockMakeParams tmpBlockMakeParams = new BlockMakeParams()
            {
                BlockType = BlockMakeType.Simple,
                SubType = new BlockMakeSubType()
                {
                    SimpleBlockType = RoyalKingdom.Block.SimpleBlock.Type.Blue
                }
            };
            blockMakeParams.Add(tmpBlockMakeParams);
        }

        for (int j = 0; j < 9; j++)
        {
            BlockMakeParams tmpBlockMakeParams = new BlockMakeParams()
            {
                BlockType = BlockMakeType.Simple,
                SubType = new BlockMakeSubType()
                {
                    SimpleBlockType = RoyalKingdom.Block.SimpleBlock.Type.Green
                }
            };
            blockMakeParams.Add(tmpBlockMakeParams);
        }

        for (int j = 0; j < 9; j++)
        {
            BlockMakeParams tmpBlockMakeParams = new BlockMakeParams()
            {
                BlockType = BlockMakeType.Simple,
                SubType = new BlockMakeSubType()
                {
                    SimpleBlockType = RoyalKingdom.Block.SimpleBlock.Type.Red
                }
            };
            blockMakeParams.Add(tmpBlockMakeParams);
        }

        for (int j = 0; j < 9; j++)
        {
            BlockMakeParams tmpBlockMakeParams = new BlockMakeParams()
            {
                BlockType = BlockMakeType.Simple,
                SubType = new BlockMakeSubType()
                {
                    SimpleBlockType = RoyalKingdom.Block.SimpleBlock.Type.Yellow
                }
            };
            blockMakeParams.Add(tmpBlockMakeParams);
        }

        for (int j = 0; j < 9; j++)
        {
            BlockMakeParams tmpBlockMakeParams = new BlockMakeParams()
            {
                BlockType = BlockMakeType.Rocket,
                SubType = new BlockMakeSubType()
                {
                    RocketType = RoyalKingdom.Block.Rocket.Type.Horizontal
                }
            };
            blockMakeParams.Add(tmpBlockMakeParams);
        }

        for (int j = 0; j < 9; j++)
        {
            BlockMakeParams tmpBlockMakeParams = new BlockMakeParams()
            {
                BlockType = BlockMakeType.Rocket,
                SubType = new BlockMakeSubType()
                {
                    RocketType = RoyalKingdom.Block.Rocket.Type.Vertical
                }
            };
            blockMakeParams.Add(tmpBlockMakeParams);
        }

        for (int j = 0; j < 9; j++)
        {
            BlockMakeParams tmpBlockMakeParams = new BlockMakeParams()
            {
                BlockType = BlockMakeType.TeddyBear,
                SubType = new BlockMakeSubType()
                {
                    TeddyBearType = RoyalKingdom.Block.TeddyBear.Type.RegularTeddyBear
                }
            };
            blockMakeParams.Add(tmpBlockMakeParams);
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                BlockMakeParams tmpBlockMakeParams = new BlockMakeParams()
                {
                    BlockType = BlockMakeType.Wood,
                    SubType = new BlockMakeSubType()
                    {
                        WoodType = RoyalKingdom.Block.Wood.Type.RegularWood
                    }
                };
                blockMakeParams.Add(tmpBlockMakeParams);
            }
        }

        for (int j = 0; j < 9; j++)
        {
            BlockMakeParams tmpBlockMakeParams = new BlockMakeParams()
            {
                BlockType = BlockMakeType.Simple,
                SubType = new BlockMakeSubType()
                {
                    SimpleBlockType = RoyalKingdom.Block.SimpleBlock.Type.Blue
                }
            };
            blockMakeParams.Add(tmpBlockMakeParams);
        }

        for (int j = 0; j < 9; j++)
        {
            BlockMakeParams tmpBlockMakeParams = new BlockMakeParams()
            {
                BlockType = BlockMakeType.Simple,
                SubType = new BlockMakeSubType()
                {
                    SimpleBlockType = RoyalKingdom.Block.SimpleBlock.Type.Blue
                }
            };
            blockMakeParams.Add(tmpBlockMakeParams);
        }

        _grid.InitializeGrid(blockMakeParams);
    }
}
