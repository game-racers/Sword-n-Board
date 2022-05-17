using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] bool isPlayer = false;

    Rigidbody2D body;

    float worldSpeedMod = 0.05f;
    float moveSpeed = 1f;
    float horizontal;
    float vertical;


    float sprintSpeed = 1f;
    float sprintMod = 1.4f;
    float sprintMaxTimer = .2f;
    float sprintTimer = 0f;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void SprintInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            sprintTimer = 0f;
        }
        if (Input.GetKey(KeyCode.LeftShift)) 
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
            sprintTimer = sprintMaxTimer;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            sprintTimer -= Time.deltaTime / 3;

            if (sprintTimer <= 0f)
            {
                sprintSpeed = 1f;
            }
            else
            {
                sprintSpeed = 1 + sprintMod * (sprintTimer / sprintMaxTimer);
            }
        }
    }

    private void FixedUpdate() 
    {
        body.position += new Vector2(horizontal * worldSpeedMod * sprintSpeed, vertical * worldSpeedMod * sprintSpeed);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Debug.Log("You fell off the map!");
        }
    }

    public void Move(float horiz, float vert)
    {
        horizontal = horiz * moveSpeed;
        vertical = vert * moveSpeed;

        if (isPlayer)
        {
            SprintInput();
        }
    }

    public void SetMover(float speed)   
    {
        moveSpeed = speed;
    }

    public void SetMover(float speed, float sSpd, float sMod, float sMaxTimer)  // if entity can sprint
    {
        moveSpeed = speed;
        sprintSpeed = sSpd;
        sprintMod = sMod;
        sprintMaxTimer = sMaxTimer;
    }
}
