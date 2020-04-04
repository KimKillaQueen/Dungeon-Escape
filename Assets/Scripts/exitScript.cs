using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitScript : interactableObject
{
    // Start is called before the first frame update
    // public Scene winScene;
    public override void Invoke() {
        SceneManager.LoadScene("win");
    }
}
