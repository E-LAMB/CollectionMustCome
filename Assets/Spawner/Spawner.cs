using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int item_no;
    public bool spawning;

    public SpawnItem[] to_spawn;

    public GameObject[] fuse_spawn_points;
    public GameObject[] key_spawn_points;
    public GameObject[] breaker_spawn_points;
    public GameObject[] locker_spawn_points;
    public GameObject[] empty_points;

    public GameObject[] spawn_points;

    public GameObject selected_spawn;
    public GameObject selected_location;
    public int selected_location_int;

    public int runs;

/*
GameObject selected = to_spawn[Random.Range(0, to_spawn.Length)];
Transform self = gameObject.GetComponent<Transform>();
if (selected != null)
{
Instantiate(selected, self.position, self.localRotation);
}
Destroy(gameObject);
*/

    // Start is called before the first frame update
    void Start()
    {
        runs = 0;
        item_no = 0;
        Spawner_Head();
    }

    void Spawner_Head()
    {
        selected_spawn = to_spawn[item_no].the_object;

        if (to_spawn[item_no].item_class == "n/a")
        {
            return;
        }

        if (to_spawn[item_no].item_class == "fuse")
        {
            spawn_points = fuse_spawn_points;
        } else if (to_spawn[item_no].item_class == "key")
        {
            spawn_points = key_spawn_points;
        } else if (to_spawn[item_no].item_class == "breaker")
        {
            spawn_points = breaker_spawn_points;
        } else if (to_spawn[item_no].item_class == "locker")
        {
            spawn_points = locker_spawn_points;
        } else
        {
            spawn_points = empty_points;
            Debug.Log("Empty Point");
        }

        if (to_spawn[item_no] == null)
        {
            return;
        }

        selected_location_int = Random.Range(0, spawn_points.Length);
        selected_location = spawn_points[selected_location_int];

        if (selected_location != null)
        {

            Instantiate(selected_spawn, selected_location.transform.position, selected_location.transform.localRotation);

            if (to_spawn[item_no].item_class == "fuse")
            {
                fuse_spawn_points[selected_location_int] = null;
            } else if (to_spawn[item_no].item_class == "key")
            {
                key_spawn_points[selected_location_int] = null;
            } else if (to_spawn[item_no].item_class == "breaker")
            {
                breaker_spawn_points[selected_location_int] = null;
            } else if (to_spawn[item_no].item_class == "locker")
            {
                locker_spawn_points[selected_location_int] = null;
            }

            item_no += 1;
            if (to_spawn[item_no] == null)
            {
                return;
            }
        }

        runs += 1;
        selected_spawn = to_spawn[item_no].the_object;
        if (to_spawn[item_no] == null)
        {
            return;
        }

        Spawner_Head();

    }



}
