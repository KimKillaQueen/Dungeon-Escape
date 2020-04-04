using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] public float movementSpeed = 3.0f;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentPos = playerRB.position;
        Vector2 moveVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        playerRB.MovePosition(currentPos + moveVec * movementSpeed * Time.fixedDeltaTime);
    }
}
