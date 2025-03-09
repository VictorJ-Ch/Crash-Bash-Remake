using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private PlayerController playerController;
    public List<GameObject>bumpers = new List<GameObject>();

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (bumpers.Contains(hit.gameObject))
        {
            playerController.StopMovement();
        }
    }
}
