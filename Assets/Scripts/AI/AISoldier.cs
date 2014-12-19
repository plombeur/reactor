using UnityEngine;
using System.Collections;

public class AISoldier : MonoBehaviour
{
    public float patrolSpeed = 2f;                          // The nav mesh agent's speed when patrolling.
    public float chaseSpeed = 5f;                           // The nav mesh agent's speed when chasing.
    public float patrolWaitTime = 1f;                       // The amount of time to wait when the patrol way point is reached.
    public Transform[] patrolWayPoints;                     // An array of transforms for the patrol route.

    private NavMeshAgent nav;                               // Reference to the nav mesh agent.
    private float patrolTimer;                              // A timer for the patrolWaitTime.
    private int wayPointIndex;                              // A counter for the way point array.

    private bool spotted = false;
    private Transform player;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (spotted)
        {
            if ((player.transform.position - transform.position).magnitude < 6)
            {
                Shooting();
            }
            else
            {
                nav.speed = chaseSpeed;
                GetComponent<AutoFire>().firing = false;
                nav.SetDestination(player.position);
            }
        }
        else
            Patrolling();
        gameObject.rigidbody.velocity = nav.velocity;
    }


    void Shooting()
    {
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        nav.Stop();
        GetComponent<AutoFire>().firing = true;
    }

    void Patrolling()
    {
        Vector3 delta = player.position - transform.position;
        Ray ray = new Ray(transform.position, delta );
        if (!Physics.Raycast(ray, delta.magnitude - 1f))
            spotted = true;
        if (patrolWayPoints.Length == 0)
            return;
        // Set an appropriate speed for the NavMeshAgent.
        nav.speed = patrolSpeed;

        // If near the next waypoint or there is no destination...
        if (nav.remainingDistance < nav.stoppingDistance)
        {
            // ... increment the timer.
            patrolTimer += Time.deltaTime;

            // If the timer exceeds the wait time...
            if (patrolTimer >= patrolWaitTime)
            {
                // ... increment the wayPointIndex.
                if (wayPointIndex == patrolWayPoints.Length - 1)
                    wayPointIndex = 0;
                else
                    wayPointIndex++;

                // Reset the timer.
                patrolTimer = 0;
            }
        }
        else
            // If not near a destination, reset the timer.
            patrolTimer = 0;

        // Set the destination to the patrolWayPoint.
        nav.destination = patrolWayPoints[wayPointIndex].position;
    }
}