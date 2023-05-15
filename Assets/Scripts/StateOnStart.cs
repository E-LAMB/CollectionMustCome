using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOnStart : MonoBehaviour
{

    public GameObject to_change;
    public bool new_state;

    // Start is called before the first frame update
    void Start()
    {
        to_change.SetActive(new_state);
    }

}
