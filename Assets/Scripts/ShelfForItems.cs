using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfForItems : MonoBehaviour
{
    [SerializeField] private List<PlantItem> itemPositions;
    [SerializeField] private TriggerZone triggerZone;
    [SerializeField] private Transform placesParent;

    private void Start()
    {
        triggerZone.OnStayPlayer01 += PasteItems;
    }

    private void PasteItems(Transform playerTransform)
    {
        var place = GetFreeItemPlaces();
        if (place != null)
        {
            var player = playerTransform.GetComponent<PlayerItems>();
            var item = player.GetItem();
            if (item == null) return;
            place.item = item;
            item.MoveToParent(place.place);
        }
    }

    private PlantItem GetFreeItemPlaces()
    {
        foreach (var place in itemPositions)
        {
            if (!place.isBusy)
                return place;
        }
        return null;
    }

    [ContextMenu(nameof(UpdatePlaces))]
    private void UpdatePlaces()
    {
        itemPositions.Clear();
        for(int i = 0; i < placesParent.childCount; i++)
        {
            var plant = new PlantItem();
            plant.place = placesParent.GetChild(i);
            itemPositions.Add(plant);
        }
    }
}