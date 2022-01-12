using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terror_ai_script : MonoBehaviour
{
    GameObject Terror;
    GameObject Player;
    Vector3 movement_direction;
    Vector3 target;
    float speed;
    float distance;
    
    Vector3 adjustment;

    void Start()
    {
        Terror = this.gameObject;
        adjustment = new Vector3(0,15.27f,0);
        Player = GameObject.Find("FirstPersonController");
        target = Player.transform.position;
        target.y = Terror.transform.position.y;
        speed = 0.2f;

    }

    // Update is called once per frame
    void Update()
    {
        adjustment.x = Terror.transform.position.x;
        adjustment.z = Terror.transform.position.z;
        Terror.transform.position = adjustment;

        target.x = Player.transform.position.x;
        target.z = Player.transform.position.z;

        movement_direction = target - Terror.transform.position;
        Terror.transform.position = Vector3.Lerp(Terror.transform.position, target, Time.deltaTime*speed);
        Terror.transform.rotation = Quaternion.Slerp(Terror.transform.rotation, Quaternion.LookRotation(movement_direction), Time.deltaTime*10f);
    }
}
