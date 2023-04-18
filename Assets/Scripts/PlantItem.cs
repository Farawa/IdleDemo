using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlantItem
{
    public bool isBusy => item != null;
    public Transform place;
    public CollectableItem item;
}
