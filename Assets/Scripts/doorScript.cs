using UnityEngine;

public class doorScript : interactableObject
{
    // Start is called before the first frame update
    private Quaternion openPos;
    private Quaternion closePos;
    private void Start() {
        if(open) {
            openPos = this.transform.rotation;
            closePos = this.transform.rotation * Quaternion.Euler(Vector3.back * 90.0f); 
        } else {
            openPos = this.transform.rotation * Quaternion.Euler(Vector3.forward * 90.0f);
            closePos = this.transform.rotation;
        }
    }

    private void Update() {
        swing();
    }

    public override void Invoke()
    {
        if (!locked)
        {
            open = !open;
        }
        else
        {
            // GetComponent<AudioSource>().Play();
        }

        PlayAudio();
    }

    private void swing()
    {
        
        if (open)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, openPos, smoothingSpeed);
        }
        else
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, closePos, smoothingSpeed);
        }
    }

    public void unlock() {
        locked = false;
    }


}
