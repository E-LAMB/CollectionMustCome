using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseScript : MonoBehaviour
{

    public int fuses_inside;
    public bool is_activated;

    public PlayerController the_player;

    public MeshRenderer my_bulb;
    public Light my_light;
    public Material activation_material;

    public GameObject[] fuses;

    public void InteractedWith()
    {
        if (!is_activated && the_player.fuses_carried > 0)
        {
            fuses_inside += 1;
            the_player.fuses_carried -= 1;
        }

        if (fuses_inside == 4)
        {
            is_activated = true;
            the_player.ExposeSelf(8f);
            my_bulb.material = activation_material;
            my_light.color = new Vector4(0f, 1f, 0f, 1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        the_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        fuses[0].SetActive(fuses_inside > 0);
        fuses[1].SetActive(fuses_inside > 1);
        fuses[2].SetActive(fuses_inside > 2);
        fuses[3].SetActive(fuses_inside > 3);
    }
}
