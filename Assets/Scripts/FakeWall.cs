using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWall : MonoBehaviour
{

    public int usual_max = 4;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(1,usual_max) == 1)
        {
            gameObject.SetActive(false);

        } 
    }

}
