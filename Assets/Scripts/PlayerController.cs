using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.1f;

    [SerializeField] float sprintSpeed = 1f;
    [SerializeField] float sprintMod = 0.1f;

    [SerializeField] float sprintMaxTimer = 1.4f;

    Mover mover;

    float horizontal;
    float vertical;

    void Start()
    {
        mover = GetComponent<Mover>();

        mover.SetMover(moveSpeed, sprintSpeed, sprintMod, sprintMaxTimer);
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        mover.Move(horizontal, vertical);
    }
}
