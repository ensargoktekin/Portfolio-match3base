using RoyalKingdom.Factory;
using System.Collections.Generic;

public interface IGrid
{
    void InitializeGrid(List<BlockMakeParams> blockMakeParams); // slotmakeparams are needed to create corresponding slots with data such as which block it has initially
    void SwapObjects(Slot slot1, Slot slot2); // initially, grid is 9x10
    void FallColumn(int columnId, int step); // step is how much the given column will be fall
}
