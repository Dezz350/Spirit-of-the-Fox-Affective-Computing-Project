using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_trigger2 : MonoBehaviour
{
    GameObject terror_mob;
    GameObject blockade;

    void Start()
    {
        terror_mob = GameObject.Find("mob_terror2");
        blockade = GameObject.Find("blockade");
        blockade.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    { 
        terror_mob.SetActive(false);
        blockade.SetActive(true);
    }
}
