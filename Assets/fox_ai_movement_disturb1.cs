using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fox_ai_movement_disturb1 : MonoBehaviour
{
    GameObject Fox;
    GameObject Fox_controller;
    List<Vector3> targets = new List<Vector3>();
    Vector3 movement_direction;
    float speed;
    float distance;
    int limit;
    int stand_limit;
    int hidden_path_limit;
    Animator fox_anim;

    GameObject Player;
    string fox_target;
    Vector3 target;
    Vector3 current_target;
    
    // Start is called before the first frame update
    void Start()
    {
        Fox_controller = this.gameObject;//GameObject.Find("fox_npc");
        Fox = GameObject.Find("fox_npc_model");
        Player = GameObject.Find("FirstPersonController");
        //movement_direction = target - Fox.transform.position;
        distance = 0;
        speed = 2f;
        limit = 0;
        stand_limit = 1;
        fox_anim = Fox.GetComponent <Animator> ();

        for(int i = 0; i < 6; i++)
        {
            fox_target = "fox_target"+(i+1);
            target = GameObject.Find(fox_target).transform.position;
            target.y = Fox.transform.position.y;
            targets.Add(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Player.transform.position,Fox.transform.position);
        if (distance<8 && limit == 0)
        {
            limit = 1;
        }
        
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
            current_target = targets[0];
            movement_direction = current_target - Fox.transform.position;
            Fox_controller.transform.position = Vector3.Lerp(Fox_controller.transform.position, current_target, Time.deltaTime*speed);
            Fox_controller.transform.rotation = Quaternion.Slerp(Fox_controller.transform.rotation, Quaternion.LookRotation(movement_direction), Time.deltaTime*10f);
        }

        if (Mathf.Floor(Fox_controller.transform.position.x) == Mathf.Floor(current_target.x) && Mathf.Floor(Fox_controller.transform.position.z) == Mathf.Floor(current_target.z))
        {
            targets.Remove(current_target);
            if (stand_limit == 0)
            {
                fox_anim.Play("Sit");
                stand_limit = 1;
            }
            fox_anim.SetBool("isIdle", true);
            fox_anim.SetBool("isRunning", false);

            movement_direction = Player.transform.position - Fox.transform.position;
            Fox_controller.transform.rotation = Quaternion.Slerp(Fox_controller.transform.rotation, Quaternion.LookRotation(movement_direction), Time.deltaTime*40f);
            current_target = Vector3.zero;
            limit = 0;
        }

    }
}