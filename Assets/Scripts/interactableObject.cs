using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObject : MonoBehaviour
{
    // Start is called before the first frame update

    public virtual void Invoke() {

    }

    public virtual void PlayAudio() {
        if(!locked) {
        if(open) {
            if(openAudio != null) {
                audioPlayer.clip = openAudio;
                audioPlayer.Play();
            }
        } else {
            if(closeAudio != null) {
                audioPlayer.clip = closeAudio;
                audioPlayer.Play();
            }
        }
        } else if(lockedAudio != null) {
            audioPlayer.clip = lockedAudio;
            audioPlayer.Play();
        }
    }

    [SerializeField] public bool open = false;
    [SerializeField] public bool locked = false;
    [SerializeField] public float smoothingSpeed = 0.5f;

    [SerializeField] public AudioClip openAudio;
    [SerializeField] public AudioClip closeAudio;
    [SerializeField] public AudioClip lockedAudio;
    [SerializeField] public AudioSource audioPlayer;
    [SerializeField] public string description = "placeholder interactable text";
}
