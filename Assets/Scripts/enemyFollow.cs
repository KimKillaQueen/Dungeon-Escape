using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 lastSeenPlayerPosition;
    private Vector2 targetDir;
    private bool chasingPlayer = false;
    [SerializeField] public float chaseSpeed = 0.7f;
    [SerializeField] public Rigidbody2D enemyRB;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = new Vector2(lastSeenPlayerPosition.x, lastSeenPlayerPosition.y);
        if(chasingPlayer && enemyRB.position !=temp) {


            // Vector2 dir = (targetPosition - currentPosition).normalized;
            Vector2 currentPosition = transform.position;
            enemyRB.MovePosition(currentPosition + targetDir * chaseSpeed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player" && !chasingPlayer) {
            Debug.Log("following player");
            Vector2 targetPosition = other.gameObject.transform.position;
            Vector2 currentPosition = transform.position;
            targetDir = (targetPosition - currentPosition).normalized;
            lastSeenPlayerPosition = other.gameObject.transform.position;
            chasingPlayer = true;
        }
    }
}
