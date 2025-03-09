using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFollower : MonoBehaviour, IBallFollower
{
    public float aiSpeed = 5f;
    public float minZ = -4.5f;
    public float maxZ = 4.5f;

    public void FollowBalls(List<Transform> ballsInGame)
    {
        Transform closestBall = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Transform ball in ballsInGame)
        {
            float distance = Vector3.Distance(transform.position, ball.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestBall = ball;
            }
        }

        if (closestBall != null)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(closestBall.position.z, minZ, maxZ));
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, aiSpeed * Time.deltaTime);
        }
    }
}
