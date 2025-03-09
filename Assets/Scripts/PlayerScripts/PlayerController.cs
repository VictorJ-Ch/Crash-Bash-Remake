using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CollisionHandler))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float gravityValue = -9.81f;


    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    

    private Vector2 movementInput = Vector2.zero;

    // Players Inputs
    public enum PlayerType{ADValue, JLValue, HBValue, UpDownValue};
    public PlayerType type;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }


    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void OnEnable()
    {
        switch (type)
        {
            case PlayerType.ADValue:
            InputHandler.OnmoveAD += MovementData;
            break;

            case PlayerType.JLValue:
            InputHandler.OnmoveJL += MovementData;
            break;

            case PlayerType.UpDownValue:
            InputHandler.OnmoveUpDown += MovementData;
            break;

            case PlayerType.HBValue:
            InputHandler.OnmoveHB += MovementData;
            break;
        }
    }


    void OnDisable()
    {
        switch (type)
        {
            case PlayerType.ADValue:
            InputHandler.OnmoveAD -= MovementData;
            break;

            case PlayerType.JLValue:
            InputHandler.OnmoveJL -= MovementData;
            break;

            case PlayerType.UpDownValue:
            InputHandler.OnmoveUpDown -= MovementData;
            break;

            case PlayerType.HBValue:
            InputHandler.OnmoveHB -= MovementData;
            break;
        }
    }


    // Seting Movement
    void MovementData(float moveData)
    {
        if(type == PlayerType.ADValue || type == PlayerType.JLValue)
        {
            movementInput.x = moveData;
            movementInput.y = 0f;
        }
        else
        {
            movementInput.y = moveData;
            movementInput.x = 0f;
        }
    }

    // Stop movement on collision
    public void StopMovement()
    {
        movementInput = Vector3.zero;
    }

}
