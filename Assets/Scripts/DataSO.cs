using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DataScriptableObject", order = 1)]
public class DataSO : ScriptableObject
{
    private static DataSO data;
    public static DataSO Data
    {
        get
        {
            if (data == null)
            {
                data = Resources.Load<DataSO>("Data");
            }
            return data;
        }
        set
        {
            data = value;
        }
    }

    [Header("Player")]
    public float PlayerSpeed = 0.1f;
    [Header("Items")]
    public float MoveDuration = 0.25f;
    [Header("Plants")]
    public float RespawnDuration = 2f;
}
