using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItenCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.addCoins();
    }
}
