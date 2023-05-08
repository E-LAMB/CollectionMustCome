using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteracter : MonoBehaviour
{

    public LayerMask interactable_layer;
    public float interact_distance;

    UnityEvent on_interact;

    public KeyCode interaction_key;

    public Transform point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(point.transform.position, point.transform.forward, out hit, interact_distance, interactable_layer))
        {
            if (hit.collider.GetComponent<Interaction>() != false)
            {
                on_interact = hit.collider.GetComponent<Interaction>().when_interacted;
                if (Input.GetKeyDown(interaction_key))
                {
                    on_interact.Invoke();
                }
            }
        }
    }

}

