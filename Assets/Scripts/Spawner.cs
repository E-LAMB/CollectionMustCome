using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] to_spawn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject selected = to_spawn[Random.Range(0, to_spawn.Length)];
        Transform self = gameObject.GetComponent<Transform>();
        if (selected != null)
        {
            Instantiate(selected, self.position, self.localRotation);
        }
        Destroy(gameObject);
    }

}
