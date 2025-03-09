using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPoolManager : MonoBehaviour
{
    public int startingBallsCount = 6;
    public GameObject ballPrefabToCreate;
    public List<GameObject> ballsCreated = new List<GameObject>();

    public void Start()
    {
        FillBallsCreatedList();
        FunctionStart();
    }

    public virtual void FunctionStart()
    {
        
    }

    public void FillBallsCreatedList()
    {
        for (int ballsInGame = 0; ballsInGame < startingBallsCount; ballsInGame++)
        {
            GameObject ballCreated = Instantiate(ballPrefabToCreate);
            ballCreated.SetActive(false);
            ballsCreated.Add(ballCreated);
        }
    }

    public GameObject AskForBalls()
    {
        GameObject returnedBalls = null;

        for (int indexCreatedBalls = 0; indexCreatedBalls < ballsCreated.Count; indexCreatedBalls++)
        {
            if (!ballsCreated[indexCreatedBalls].activeInHierarchy)
            {
                returnedBalls = ballsCreated[indexCreatedBalls];
                returnedBalls.SetActive(true);
                break;
            }
        }
        return returnedBalls;
    }
}
