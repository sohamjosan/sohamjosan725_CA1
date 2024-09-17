using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    Vector2 movementInput;


    public float movementspeed = 1f;
    public float jumpspeed = 20f;
    public float gravity = 9.8f;
    public float verticalspeed = 0;
    public void IAMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void IAJump(InputAction.CallbackContext context)
    {
        if (context.started == true && GroundCheck())
        {
            verticalspeed = jumpspeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (GroundCheck() == true && verticalspeed <= 0)
            {

                verticalspeed = 0;
            }
            else
            {
                verticalspeed = verticalspeed - gravity * Time.deltaTime;
            }

            transform.Translate(movementInput.x * movementspeed * Time.deltaTime, verticalspeed * Time.deltaTime, movementInput.y * movementspeed * Time.deltaTime);
        }
    }
    public bool GroundCheck()
    {
        return Physics.Raycast(transform.position, transform.up * -1, 1.2f);
    }
}
   
