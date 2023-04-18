using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private CollectableItem plantPrefab;
    [SerializeField] private List<PlantItem> itemPositions;
    [SerializeField] private TriggerZone triggerZone;
    private void Start()
    {
        StartCoroutine(UpdatePlantItems());
        triggerZone.OnStayPlayer01 += MoveItemToPlayer;
    }

    private IEnumerator UpdatePlantItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(DataSO.Data.RespawnDuration);
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        PlantItem place = null;
        foreach (var item in itemPositions)
        {
            if (!item.item)
            {
                place = item;
                break;
            }
        }
        if (place != null)
        {
            place.item = Instantiate(plantPrefab, place.place);
            place.item.transform.position = place.place.position + Vector3.down;
            place.item.MoveToParent(place.place);
        }
    }

    private void MoveItemToPlayer(Transform playerTransform)
    {
        var player = playerTransform.GetComponent<PlayerItems>();
        if (player == null) return;
        foreach (var item in itemPositions)
        {
            if (item.isBusy)
            {
                if (player.AddItem(item.item))
                {
                    item.item = null;
                }
                return;
            }
        }
    }
}