using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fox_movement1_script : MonoBehaviour
{
    GameObject Fox;
    GameObject Fox_controller;
    Vector3 target;
    Vector3 movement_direction;
    float speed;
    int limit;
    int stand_limit;
    Animator fox_anim;
    
    // Start is called before the first frame update
    void Start()
    {
        Fox_controller = GameObject.Find("fox_npc");
        Fox = GameObject.Find("fox_npc_model");
        target = GameObject.Find("fox_target").transform.position;
        target.y = Fox.transform.position.y;
        movement_direction = target - Fox.transform.position;
        speed = 0.3f;
        limit = 0;
        stand_limit = 1;
        fox_anim = Fox.GetComponent <Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (limit == 1)
        {
            if (stand_limit == 1)
            {
                fox_anim.Play("Stand");
                stand_limit = 0;
            }
            fox_anim.SetBool("isRunning", true);
            fox_anim.SetBool("isIdle", false);
        }
        if (fox_anim.GetCurrentAnimatorStateInfo(0).IsName("Run_state"))
        {
            Fox_controller.transform.position = Vector3.Lerp(Fox_controller.transform.position, target, Time.deltaTime*speed);
            Fox_controller.transform.rotation = Quaternion.Slerp(Fox_controller.transform.rotation, Quaternion.LookRotation(movement_direction), Time.deltaTime*5f);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        limit = 1;
    }
}
