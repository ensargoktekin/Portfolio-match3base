using RoyalKingdom.Block;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace RoyalKingdom.Factory
{
    public enum BlockMakeType
    {
        None,
        Simple,
        Rocket,
        Wood,
        TeddyBear
    }

    // Union keeps the subtype of a block
    [StructLayout(LayoutKind.Explicit)]
    public struct BlockMakeSubType
    {
        [FieldOffset(0)] public SimpleBlock.Type SimpleBlockType;
        [FieldOffset(0)] public Rocket.Type RocketType;
        [FieldOffset(0)] public Wood.Type WoodType;
        [FieldOffset(0)] public TeddyBear.Type TeddyBearType;

    }

    public struct BlockMakeParams
    {
        public BlockMakeType BlockType;
        public BlockMakeSubType SubType;

        public override string ToString()
        {
            string str = "";
            str += $"BlockType: {BlockType}\n";
            str += $"SubType: {SubType}\n";
            return str;
        }
    }
}
