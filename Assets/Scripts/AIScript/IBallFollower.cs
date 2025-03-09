using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallFollower
{
    void FollowBalls(List<Transform> ballsInGame);
}
