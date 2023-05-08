using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{

    public UnityEvent when_interacted;

    [Header("Monster Interactions")]
    [Tooltip("Alerts the monster to the player's presence for three seconds.")]
    public bool OI_alert_monster;

    [Header("Item Interactions")]
    [Tooltip("Adds a fuse to the player's inventory.")]
    public bool OI_add_fuse;
    [Tooltip("Adds a key to the player's inventory.")]
    public bool OI_add_key;
    [Tooltip("Specifies which key to add to their inventory (Only needed if a key is being added).")]
    public string OI_key_to_add;

    [Header("Destroying Interactions")]
    [Tooltip("Destroys the Gameobject after all interactions have been done.")]
    public bool OI_destroy_self;
    [Tooltip("Determines how long it takes to destroy the Gameobject.")]
    public float OI_destroy_time;

    [Header("Door Interactions")]
    [Tooltip("Is this Gameobject a door?")]
    public bool OI_is_door;
    [Tooltip("Does this door need a key, If so what key? (Leave as U for an unlocked door)")]
    public string OI_door_key_required;

    public void UsedSelf()
    {
        if (OI_alert_monster)
        {
            // Debug.Log("Alerted the monster to your presence");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ExposeSelf(3f);
            Debug.Log("Exposed Player for three seconds.");
        }

        if (OI_add_fuse)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GotFuse();
            Debug.Log("Added a fuse to the player's inventory");
        }
        if (OI_add_key)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().key_inventory += "/" + OI_key_to_add;
            Debug.Log("Added a key to the player's inventory: " + OI_key_to_add);
        }

        if (OI_is_door)
        {
            if (OI_door_key_required == "U")
            {
                gameObject.GetComponent<DoorScript>().DoorChange();
            } else 
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().key_inventory.Contains(OI_door_key_required))
                {
                    gameObject.GetComponent<DoorScript>().DoorChange();
                } else
                {
                    Debug.Log("Door is shut - No action");
                }
            }
        }

        if (OI_destroy_self)
        {
            Debug.Log("Deleted Self.");
            Destroy(gameObject, OI_destroy_time);
        }
    }

}
