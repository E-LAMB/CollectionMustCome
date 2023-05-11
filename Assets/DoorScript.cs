using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public bool is_open;

    public float open_direction;
    public float closed_direction;

    public Transform hinge;

    float r;
    public float new_angle;

    public bool is_double_door;
    public DoorScript other_door;

    public void DoorChange()
    {
        is_open = !is_open;
        if (is_double_door)
        {
            other_door.DoubleDoorChange();
        }
    }

    public void DoubleDoorChange()
    {
        is_open = !is_open;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is_open)
        {
            new_angle = Mathf.SmoothDampAngle(hinge.eulerAngles.y, open_direction, ref r, 0.1f);
        } else
        {
            new_angle = Mathf.SmoothDampAngle(hinge.eulerAngles.y, closed_direction, ref r, 0.1f);
        }

        hinge.localRotation = Quaternion.Euler(0f,new_angle,0f);

    }
}
