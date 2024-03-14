using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItenCollectableBase
{
    // Start is called before the first frame update
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.addCoins();
    }
}
