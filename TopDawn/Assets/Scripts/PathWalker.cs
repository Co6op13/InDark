using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathWalker : MonoBehaviour
{
    [SerializeField] private EnemyAI ai;
    [SerializeField] private Seeker seeker;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float slowdown;
    [SerializeField] private float nextWaipointDistance;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public float endReachedDistance;
    [SerializeField] public float slowdownDistance;
    [SerializeField] private float currentSpeed;
    private Path path;
    private int currentWaypoint = 0;
   // private bool endOfpath = false;

    void Start()
    {
        ai = GetComponent<EnemyAI>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }


    void UpdatePath()
    {
        if (ai.TargetToMovie != null && seeker.IsDone())
        {
            seeker.StartPath(rb.position, ai.TargetToMovie.position, OnPathComplite);
        }
    }

    void OnPathComplite(Path path)
    {
        if (!path.error)
        {
            this.path = path;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (path == null)
            return;


        if (currentWaypoint >= path.vectorPath.Count)
            return;

        if (ai.CanMovie)
        {
            Move();
            GetNextWaypoint();
        }
    }

    private void Move()
    {
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        if (Vector2.Distance(rb.position, ai.TargetToMovie.position) < endReachedDistance)
            currentSpeed = 0f;
        else
        {
            if (Vector2.Distance(rb.position, ai.TargetToMovie.position) > slowdownDistance)
                currentSpeed = maxSpeed;
            else
                currentSpeed = maxSpeed * 0.5f;
        }

        rb.AddForce(direction * currentSpeed);
    }

    private void GetNextWaypoint()
    {
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaipointDistance)
        {
            currentWaypoint++;
        }
    }
}
