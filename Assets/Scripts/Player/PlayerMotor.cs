 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    public float speed = 5f;
    public float gravity = -9.8f;
    bool isGrounded;
    public float jumpHeight = 3f;
    bool lerpCrouch;
    bool sprinting = false;
    bool crouching = false;
    private float crouchTimer;
   

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded; // update each Frame if player touching ground
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                characterController.height = Mathf.Lerp(characterController.height, 1, p);
            else
                characterController.height = Mathf.Lerp(characterController.height, 2, p);

            if (p>1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    // receive the inputs for our InputManager.cs and apply them to our character controller
    public void ProcessMove (Vector2 input)
    {
        Vector3 moveDiretion = Vector3.zero;
        moveDiretion.x = input.x;
        moveDiretion.z = input.y;
        characterController.Move (transform.TransformDirection(moveDiretion) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        characterController.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }

    public void OnJump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Sprint()
    { 
        sprinting = !sprinting;
        if (sprinting)
            speed = 10f;
        else
            speed = 5f;
     }
}
