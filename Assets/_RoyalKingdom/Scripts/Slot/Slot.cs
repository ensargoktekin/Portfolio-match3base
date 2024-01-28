using RoyalKingdom.Block;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour, ISlot
{
    [SerializeField] private RoyalKingdom.Block.BaseBlock _block;
    [SerializeField] private State _state;

    public enum State
    {
        None,
        HasItem,
        WaitingItem,
        Swapping
    }

    public bool CanSwap
    {
        get
        {
            if (_state == State.HasItem)
            {
                return _block.CanSwap;
            }
            return false;
        }
    }

    public bool CanFall
    {
        get
        {
            if (_state == State.HasItem)
            {
                return _block.CanFall;
            }
            return false;
        }
    }

    public void PopBlock()
    {
        _block.Pop();
        _block = null;
        _state = State.WaitingItem;
    }

    public BaseBlock ReleaseBlock()
    {
        BaseBlock releasedBlock = _block;
        _block = null;
        _state = State.WaitingItem;
        return releasedBlock;
    }

    public void LocateInitialBlock(BaseBlock block)
    {
        _block = block;
        _state = State.HasItem;
        _block.transform.position = transform.position; // change this with no anim
    }

    public void SetBlock(BaseBlock block)
    {
        _block = block;
        _state = State.HasItem;
    }

    public void NewBlockFall(BaseBlock block)
    {
        throw new System.NotImplementedException();
    }

    public void AnimateSwapNewBlock(BaseBlock block)
    {
        // dotween anim + setblock
        block.SwapTo(transform.position);
        SetBlock(block); // call this in callback
    }
}
