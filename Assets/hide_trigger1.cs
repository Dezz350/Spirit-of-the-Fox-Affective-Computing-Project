using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_trigger1 : MonoBehaviour
{
    GameObject terror_mob;

    void Start()
    {
        terror_mob = GameObject.Find("mob_terror");
    }

    void OnTriggerEnter(Collider other)
    { 
        terror_mob.SetActive(false);
    }
}
