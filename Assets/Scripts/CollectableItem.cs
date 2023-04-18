using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableItem : MonoBehaviour
{
    public void MoveToParent(Transform parent, bool isInstantly = false)
    {
        transform.SetParent(parent);
        if (isInstantly)
        {
            transform.localPosition = Vector3.zero;
        }
        else
        {
            transform.DOLocalMove(Vector3.zero, DataSO.Data.MoveDuration);
        }
    }

    public void Stop()
    {
        transform.DOKill();
    }
}