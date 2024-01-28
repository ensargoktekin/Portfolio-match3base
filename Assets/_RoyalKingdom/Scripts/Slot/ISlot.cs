using RoyalKingdom.Block;
using UnityEngine;

public interface ISlot
{
    void LocateInitialBlock(BaseBlock block);
    void SetBlock(RoyalKingdom.Block.BaseBlock block); // called when a new block has arrived
    void NewBlockFall(BaseBlock block);
    BaseBlock ReleaseBlock(); // called when current block start to fall to different slot or after swapping
    void PopBlock(); // called when current block is destroyed via matching (after swapping or falling)
    void AnimateSwapNewBlock(BaseBlock block); // swap block to position
}
