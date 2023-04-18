using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public Action<Transform> OnEnterPlayer;
    public Action<Transform> OnStayPlayer01;
    public Action<Transform> OnStayPlayerEveryTick;
    private float lastStay01;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        Debug.Log("Enter");
        OnEnterPlayer?.Invoke(other.transform);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (lastStay01 + 0.1f <= Time.time)
            {
                Debug.Log("Stay 0.1");
                OnStayPlayer01?.Invoke(other.transform);
                lastStay01 = Time.time;
            }
            Debug.Log("Stay 0.02");
            OnStayPlayerEveryTick?.Invoke(other.transform);
        }
    }
}