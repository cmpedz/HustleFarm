using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedsItem : GameObjectHolderItem<HarvestPlantsController>
{
    public override void ItemClickedEvents()
    {
        if(GetItemHolder() != null)
        {
            GetItemHolder().UserBag = UserBag;

            DirtStatusControllerSystem.Instance.SeedProvided = GetItemHolder();

            DirtStatusControllerSystem.Instance.SeedItemInBagClicked = this;
        }

        DirtStatusControllerSystem.Instance.ActiveSymbolOfEmptyDirt(true);

        if(UserBag != null)
        {
            UserBag.gameObject.SetActive(false);
        }
    }

}
