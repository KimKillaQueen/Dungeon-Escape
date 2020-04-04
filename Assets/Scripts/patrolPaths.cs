using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class patrolPaths : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public List<Transform> patrolPoints;
    [SerializeField] private AIDestinationSetter targetDestination;
    public bool isPatrolling = true;
    private int currentIndex = 0;
    void Start()
    {
        targetDestination = GetComponent<AIDestinationSetter>();
        targetDestination.target = patrolPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        // if (isPatrolling)
        // {
            Vector2 currentTargetPos = targetDestination.target.transform.position;
            Vector2 currentPos = transform.position;
            if ((currentTargetPos - currentPos).magnitude < 0.2f)
            {
                currentIndex++;
                if (currentIndex >= patrolPoints.Count)
                {
                    currentIndex = 0;
                }

                targetDestination.target = patrolPoints[currentIndex];
            }

            if(isPatrolling == false && (currentTargetPos - currentPos).magnitude > 3.0f) {
                targetDestination.target = patrolPoints[currentIndex];
            }
        // }
    }

    public void startPlayerChase() {
        isPatrolling = false;
        Debug.Log("Started chasing player");
        targetDestination.target = GameObject.Find("Player").transform;
        
    }
}
