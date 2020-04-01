using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine
// using UnityEngine.UIElements;
// using UnityEngine.UI;

public class Intereaction : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float IntereactionRadius = 3.0f;
    private List<interactableObject> allInteractables;
    void Start()
    {
        allInteractables = new List<interactableObject>(FindObjectsOfType<interactableObject>());
    }

    // Update is called once per frame
    void Update()
    {
        checkForInteractable();
        if(Input.GetKeyDown(KeyCode.F)) {
            isNearInteractable();
        }
    }


    private void isNearInteractable() {
        // var allInteractables = new List<interactableObject>(FindObjectsOfType<interactableObject>());

        var target = allInteractables.Find(delegate (interactableObject interactable) {
            Vector2 interactablePos = interactable.transform.position;
            Vector2 playerPos = gameObject.transform.position;

            return (interactablePos - playerPos).magnitude <= IntereactionRadius;
        });

        if(target != null) {
            target.Invoke();
        } else {
            Debug.Log("No target");
        }
    }

    private void checkForInteractable() {
        var target = allInteractables.Find(delegate (interactableObject interactable) {
            Vector2 interactablePos = interactable.transform.position;
            Vector2 playerPos = gameObject.transform.position;

            return (interactablePos - playerPos).magnitude <= IntereactionRadius;
        });

        if( target != null) {
            interactableTextField.text = target.description;
        } else {
            interactableTextField.text = "";
        }
    }

    [SerializeField]  Text interactableTextField;
}
