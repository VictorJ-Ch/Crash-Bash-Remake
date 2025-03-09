using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : BallPoolManager
{
    public float timeToSpawn = 3;
    public List<Transform> ballLocation = new List<Transform>();

    public override void FunctionStart()
    {
        StartCoroutine(SpawningBalls());
    }

    IEnumerator SpawningBalls()
    {
        while (true)
        {
            int randomBallLocation = Random.Range(0, ballLocation.Count);
            GameObject ball = AskForBalls();
            if (ball != null)
            {
                ball.transform.position = ballLocation[randomBallLocation].position;
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
