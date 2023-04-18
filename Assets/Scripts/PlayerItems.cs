using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private List<PlantItem> plantItems;

    public bool AddItem(CollectableItem collectableItem)
    {
        foreach (var item in plantItems)
        {
            if (!item.isBusy)
            {
                collectableItem.MoveToParent(item.place);
                item.item = collectableItem;
                return true;
            }
        }
        return false;
    }

    public CollectableItem GetItem()
    {
        CollectableItem targetItem = null;
        for (int i = plantItems.Count - 1; i >= 0; i--)
        {
            if (plantItems[i].isBusy)
            {
                targetItem = plantItems[i].item;
                plantItems[i].item = null;
                break;
            }
        }
        return targetItem;
    }
}
