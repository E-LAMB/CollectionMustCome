using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        gameObject.transform.position = new Vector3 (gameObject.transform.position.x + Random.Range(-2f, 2f), gameObject.transform.position.y, gameObject.transform.position.z + Random.Range(-2f, 2f));   
        Destroy(gameObject.GetComponent<TreeScript>());
    
    }


}
