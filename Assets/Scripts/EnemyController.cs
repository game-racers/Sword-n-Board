using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.1f;

    [SerializeField] float sprintSpeed = 1f;
    [SerializeField] float sprintMod = 0.1f;

    [SerializeField] float sprintMaxTimer = 1.4f;
    [SerializeField] bool canSprint = false;

    Mover mover;

    float horizontal;
    float vertical;

    void Start()
    {
        mover = GetComponent<Mover>();

        if (canSprint)
            mover.SetMover(moveSpeed, sprintSpeed, sprintMod, sprintMaxTimer);
        else
            mover.SetMover(moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
