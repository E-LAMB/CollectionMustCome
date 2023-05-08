using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float yaw, pitch;
    private Rigidbody rb;
    public float speed, sensitivity;

    public bool should_be_in_control;

    public GameObject my_camera;

    public Transform self;

    public KeyCode key_aura;
    public float aura_transition_time;

    public GameObject go_cam_norm;
    public GameObject go_cam_aura;

    public Material aura_material_enemy;
    public Material aura_material_objective;
    public Material aura_material_secondary;

    public float emission_amount;
    public AnimationCurve aura_curve;

    public int fuses_carried;
    public float exposure_time;

    public string key_inventory;

    public void ExposeSelf(float time_to_expose)
    {
        if (time_to_expose > exposure_time)
        {
            exposure_time = time_to_expose;
        }
    }

    public void GotFuse()
    {
        fuses_carried += 1;
    }
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
        Mind.reveal_auras = false;
    }

    private void Update()
    {

        exposure_time -= Time.deltaTime;

        if (should_be_in_control)
        {
            //Camera Control
            if (should_be_in_control)
            {
                Cursor.lockState = CursorLockMode.Locked;
                pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
                pitch = Mathf.Clamp(pitch, -90, 90);
                yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
                my_camera.transform.localRotation = Quaternion.Euler(pitch, yaw, 0); 

                if (Input.GetKeyDown(key_aura))
                {
                    Mind.reveal_auras = !Mind.reveal_auras;
                    aura_transition_time = 0f;
                } 

                go_cam_norm.SetActive(!Mind.reveal_auras);
                go_cam_aura.SetActive(Mind.reveal_auras);

                if (aura_transition_time < 5f && Mind.reveal_auras) {aura_transition_time += Time.deltaTime * 2f;}

                emission_amount = aura_curve.Evaluate(aura_transition_time);
                
                aura_material_enemy.color = new Vector4(1f, 0f, 0f, emission_amount);
                aura_material_objective.color = new Vector4(1f, 1f, 0.5f, emission_amount);
                aura_material_secondary.color = new Vector4(1f, 0.5f, 0f, emission_amount);

            } else
            {
                // nothing happens
            }
        }
    }

    private void FixedUpdate()
    {
        if (should_be_in_control) // The condition that would stop you
        {
            Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * speed;
            Vector3 forward = new Vector3(-my_camera.transform.right.z, 0, my_camera.transform.right.x);
            Vector3 wishDirection = (forward * axis.x + my_camera.transform.right * axis.y + Vector3.up * rb.velocity.y);
            rb.velocity = wishDirection;
        } else
        {
            // nothing happens
        }
    }
}
