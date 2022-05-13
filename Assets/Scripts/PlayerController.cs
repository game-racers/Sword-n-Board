using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //These fields will be exposed to Unity so the dev can set the parameters there
    [SerializeField] float speed = 0.1f;
    [SerializeField] float sprintMod = 1.4f;

    Rigidbody2D body;

    float moveSpeed = 1f;
    float sprintSpeed = 1f;
    float horizontal;
    float vertical;
    float runSpeed = 5f;
    float sprintMaxTimer = .2f;
    float sprintTimer = 0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * runSpeed;
        vertical = Input.GetAxis("Vertical") * runSpeed;

        SprintInput();
    }

    void SprintInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) // needs to slowly apply, not instant
        {
            sprintTimer = 0f;
        }
        if (Input.GetKey(KeyCode.LeftShift)) // shift held down
        {
            sprintTimer += Time.deltaTime;
            if (sprintTimer > sprintMaxTimer)
            {
                sprintSpeed = 1 + sprintMod;
            }
            else
            {
                sprintSpeed = 1 + sprintMod * (sprintTimer / sprintMaxTimer);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprintSpeed = 1f;
            sprintTimer = sprintMaxTimer;
        }
        // if (!Input.GetKey(KeyCode.LeftShift))
        // {
        //     sprintTimer -= Time.deltaTime;

        //     if (sprintTimer >= 0f)
        //     {
        //         sprintSpeed = 1f;
        //     }
        //     else
        //     {
        //         sprintSpeed = 1 + sprintMod * (sprintTimer / sprintMaxTimer);
        //     }
        // }
    }

    private void FixedUpdate()
    {
       body.position += new Vector2(horizontal * speed * sprintSpeed, vertical * speed * sprintSpeed);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Debug.Log("You fell off the map!");
        }
    }
}
