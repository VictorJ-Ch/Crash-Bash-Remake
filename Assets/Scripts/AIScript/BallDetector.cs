using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallDetector : MonoBehaviour, IBallDetector
{
    public LayerMask ballLayerMask;

    public List<Transform> DetectBalls()
    {
        List<Transform> ballsInGame = new List<Transform>();
        Collider[] colliders = Physics.OverlapSphere(transform.position, Mathf.Infinity, ballLayerMask);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.activeInHierarchy)
            {
                ballsInGame.Add(collider.transform);
            }
        }

        return ballsInGame;
    }
}
