using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Animator playerAnimator;
    private bool isMoving = false;

    private void FixedUpdate()
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MoveOnDirection(direction);
        isMoving = direction != Vector2.zero;
        playerAnimator.SetBool("IsMoving", isMoving);
    }

    public void MoveOnDirection(Vector2 direction)
    {
        LookAtDirection(direction);
        playerRigidbody.MovePosition(transform.position + V2ToV3(direction).normalized * DataSO.Data.PlayerSpeed);
    }

    private void LookAtDirection(Vector2 direction)
    {
        var lookPosition = playerTransform.position + V2ToV3(direction);
        playerTransform.LookAt(lookPosition);
    }

    private Vector3 V2ToV3(Vector2 vector2)
    {
        return new Vector3(vector2.x, 0, vector2.y);
    }
}
