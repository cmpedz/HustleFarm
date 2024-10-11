using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedsItem : GameObjectHolderItem<HarvestPlantsController>
{
    public override void ItemClickedEvents()
    {
        if(GetItemHolder() != null)
        {
            GetItemHolder().UserBag = bagMenu;

            DirtStatusControllerSystem.Instance.SeedProvided = GetItemHolder().gameObject;
        }

        DirtStatusControllerSystem.Instance.ActiveSymbolOfEmptyDirt(true);

        if(bagMenu != null)
        {
            bagMenu.gameObject.SetActive(false);
        }
    }

}
