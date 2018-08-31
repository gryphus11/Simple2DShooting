using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemEnemyShipHealth : CShipHealth
{
    public override void DoDestroy()
    {
        CItemDrop itemDrop = GetComponent<CItemDrop>();

        if (itemDrop != null)
            itemDrop.ItemDrop();

        base.DoDestroy();
    }
}
