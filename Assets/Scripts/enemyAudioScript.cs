using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip patrollingAudio;
    public AudioClip chasingAudio;
    public AudioClip shriekAudio;
    private AudioSource audioPlayer;
    private Transform playerTransform;
    public bool chasingPlayer = false;
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.clip = patrollingAudio;
        audioPlayer.loop = true;
        audioPlayer.Play();
        playerTransform = FindObjectOfType<Intereaction>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = playerTransform.position;
        Vector2 currentPos = transform.position;
        float distance = (playerPos - currentPos).magnitude;
        if(!chasingPlayer) {


        
        if(distance == 0) {
            audioPlayer.volume = 1.0f;
        } else {
        
        }
        } else {
            if(!audioPlayer.isPlaying) {
                audioPlayer.clip = chasingAudio;
            }
        }
        if(distance > 0) {
            audioPlayer.volume = 4.0f / (distance * distance * distance);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") {
            Debug.Log("Encountered------------------------------------------- player");
            audioPlayer.clip = shriekAudio;
            audioPlayer.loop = false;
            audioPlayer.volume = 1.0f;
            audioPlayer.Play();
            chasingPlayer = true;
            GetComponentInParent<patrolPaths>().startPlayerChase();
        }


    }


}
