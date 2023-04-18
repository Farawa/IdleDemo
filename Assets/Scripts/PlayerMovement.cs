using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody playerRigidbody;
    private void FixedUpdate()
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MoveOnDirection(direction);
    }

    public void MoveOnDirection(Vector2 direction)
    {
        LookAtDirection(direction);
        playerRigidbody.MovePosition(transform.position + TransformToV3(direction).normalized * DataSO.Data.PlayerSpeed);
    }

    private void LookAtDirection(Vector2 direction)
    {
        var lookPosition = playerTransform.position + TransformToV3(direction);
        playerTransform.LookAt(lookPosition);
    }

    private Vector3 TransformToV3(Vector2 vector2)
    {
        return new Vector3(vector2.x, 0, vector2.y);
    }
}
