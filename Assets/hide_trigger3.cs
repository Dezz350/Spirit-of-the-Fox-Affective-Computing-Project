using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_trigger3 : MonoBehaviour
{
    GameObject mob_terror;
    GameObject terror_destination;
    int out_trigger;
    Vector3 target;

    GameObject Player;
    GameObject destination;
    GameObject light_source;
    Light terror_light;
    float distance;

    void Start()
    {
        mob_terror = GameObject.Find("terror_out");
        terror_destination = GameObject.Find("terror_target");
        target = terror_destination.transform.position;
        out_trigger = 0;

        Player = GameObject.Find("FirstPersonController");
        destination = GameObject.Find("scene_changer");
        light_source = GameObject.Find("Directional Light");
        terror_light = light_source.GetComponent<Light>();
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Player.transform.position,destination.transform.position);

        if (out_trigger == 1)
        {
            terror_light.intensity = distance*0.025f;
            StartCoroutine(TimeLockedMovement(1, mob_terror));
        }

        if (terror_light.intensity > 1)
        {
            terror_light.intensity = 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        out_trigger = 1;
    }

    IEnumerator TimeLockedMovement(int sec, GameObject obj)
    {
        yield return new WaitForSeconds(sec);
        obj.transform.position = Vector3.Lerp(obj.transform.position, target, Time.deltaTime*1f);
    }
}
