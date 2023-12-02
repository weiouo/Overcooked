using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttingboard : BaseCounter
{
    public override void Interact(Player player)
    {
        //基本上跟ClearCounter一樣
        //只是要判斷何者可以上切台
    }
    public override void Cut()
    {
        Debug.Log("cut");
    }
}
