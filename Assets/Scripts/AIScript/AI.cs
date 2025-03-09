using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    private IBallDetector ballDetector;
    private IBallFollower ballFollower;

    void Start()
    {
        ballDetector = GetComponent<IBallDetector>();
        ballFollower = GetComponent<IBallFollower>();
    }

    void Update()
    {
        List<Transform> ballsInGame = ballDetector.DetectBalls();
        if (ballsInGame.Count > 0)
        {
            ballFollower.FollowBalls(ballsInGame);
        }
    }
}
