using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSFXscript : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource walkSFX;
    private Rigidbody2D playerRB;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        if(GetComponent<AudioSource>()) {
            walkSFX = GetComponent<AudioSource>();
            walkSFX.loop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            if(walkSFX.isPlaying == false) {
                walkSFX.Play();
            }
        } else {
            walkSFX.Stop();
        }
    }
}
