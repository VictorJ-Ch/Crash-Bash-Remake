using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    public float ballSpeed = 5f;

    public delegate void CollisionWithField(GameObject field);
    public CollisionWithField onCollisionWithField;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        NewBallDirection();
    }

    void Update()
    {
        BallMovement();
    }

    private void BallMovement()
    {
        rb.MovePosition(transform.position + rb.velocity * Time.deltaTime);
    }

    private void NewBallDirection()
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        ).normalized;
        rb.velocity = randomDirection * ballSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        NewBallDirection();
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
