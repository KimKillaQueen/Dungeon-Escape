using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyPickup : interactableObject
{
    // Start is called before the first frame update
    public override void Invoke() {
        GameObject.Find("Player").GetComponent<Intereaction>().giveKey();
        description = "";
        GetComponent<SpriteRenderer>().enabled = false;
        // Destroy(gameObject);
    }




}
