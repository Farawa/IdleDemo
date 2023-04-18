using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [ContextMenu(nameof(Open))]
    public void Open()
    {
        animator.SetBool("IsOpen", true);
    }

    [ContextMenu(nameof(Close))]
    public void Close()
    {
        animator.SetBool("IsOpen", false);
    }
}
