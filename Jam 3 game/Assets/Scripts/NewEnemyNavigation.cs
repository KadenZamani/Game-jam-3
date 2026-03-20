using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyNavigation : MonoBehaviour
{
    enum MovementTypes
    {
        Chase,
        Patrol
    }

    [SerializeField] MovementTypes currentMovementType;
    [SerializeField] GameObject player;

    NavMeshAgent agent;

    [Header("Detection")]
    [SerializeField] float detectionRange = 10f;
    [SerializeField] float refreshRate = 0.2f;

    [Header("Patrol")]
    Vector3 patrolStartPosition;
    Vector3 patrolEndPosition;
    bool goingToEnd = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        patrolStartPosition = transform.position;

        // find patrol end point in front of enemy
        if (Physics.Raycast(transform.position + Vector3.up * 5f,
                            transform.forward,
                            out RaycastHit hit,
                            20f))
        {
            patrolEndPosition = hit.point;
        }
        else
        {
            patrolEndPosition = transform.position + transform.forward * 10f;
        }

        currentMovementType = MovementTypes.Patrol;

        StartCoroutine(AILoop());
    }

    IEnumerator AILoop()
    {
        while (true)
        {
            float distToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // SWITCH STATES
            if (distToPlayer < detectionRange)
                currentMovementType = MovementTypes.Chase;
            else
                currentMovementType = MovementTypes.Patrol;

            // EXECUTE STATE
            switch (currentMovementType)
            {
                case MovementTypes.Chase:
                    agent.SetDestination(player.transform.position);
                    break;

                case MovementTypes.Patrol:
                    PatrolBehavior();
                    break;
            }

            yield return new WaitForSeconds(refreshRate);
        }
    }

    void PatrolBehavior()
    {
        Vector3 target = goingToEnd ? patrolEndPosition : patrolStartPosition;

        agent.SetDestination(target);

        if (!agent.pathPending && agent.remainingDistance < 0.3f)
        {
            goingToEnd = !goingToEnd;
        }
    }
}