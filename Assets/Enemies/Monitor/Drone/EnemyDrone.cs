using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{

    public Transform drone_hover;
    public Transform final_handler;

    public bool is_moving;
    public Vector3 drone_euler;
    public AnimationCurve drone_move_hover_height;
    public float drone_hover_height_timer;

    public float default_height;

    public Vector3 target_location;
    public float target_distance;

    public float movement_speed;

    public Transform head_spin;
    public AnimationCurve turn_curve;
    public float turn_time;
    public float turn_time_rotor;

    public Transform[] rotors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        drone_hover_height_timer += Time.deltaTime / 3f;

        turn_time += Time.deltaTime / 4f;
        turn_time_rotor += Time.deltaTime * 15f;

        // turn_time += Random.Range(1f, 4f);

        /*
        if (turn_time > 3600f)
        {
            turn_time = 0f;
        }
        if (turn_time_rotor > 3600f)
        {
            turn_time_rotor = 0f;
        }
        */
        
        head_spin.localRotation = Quaternion.Euler(0f, turn_curve.Evaluate(turn_time), 0f);

        rotors[0].localRotation = Quaternion.Euler(-90f, turn_curve.Evaluate(turn_time_rotor), 0f);
        rotors[1].localRotation = Quaternion.Euler(-90f, turn_curve.Evaluate(turn_time_rotor), 0f);
        rotors[2].localRotation = Quaternion.Euler(-90f, (turn_curve.Evaluate(turn_time_rotor) * -1f), 0f);
        rotors[3].localRotation = Quaternion.Euler(-90f, (turn_curve.Evaluate(turn_time_rotor) * -1f), 0f);

        if (is_moving)
        {
            target_distance = Vector3.Distance(final_handler.position, target_location);
            if (target_distance < 0.2f)
            {
                // is_moving = false;
                Debug.Log("Arrived at Destination");
            }

            final_handler.position = Vector3.MoveTowards(final_handler.position, target_location, movement_speed * Time.deltaTime);
            drone_hover.localPosition = new Vector3 (0f, default_height + (drone_move_hover_height.Evaluate(drone_hover_height_timer) / 5f), 0f);
            
            /*
            drone_hover.LookAt(target_location);
            drone_euler = drone_hover.eulerAngles;
            drone_euler.x = Mathf.Clamp(drone_euler.x, 10f, -10f);
            // drone_euler.y = Mathf.Clamp(drone_euler.y, 10f, -10f);
            drone_euler.z = Mathf.Clamp(drone_euler.z, 10f, -10f);
            drone_euler = drone_euler * -1f;
            drone_hover.localEulerAngles = drone_euler;
            */

        } else
        {
            drone_hover.localPosition = new Vector3 (0f, default_height + (drone_move_hover_height.Evaluate(drone_hover_height_timer)/2f), 0f);
            drone_euler = new Vector3 (0f, 0f, 0f);
            drone_hover.localEulerAngles = drone_euler;
        }
    }
}
