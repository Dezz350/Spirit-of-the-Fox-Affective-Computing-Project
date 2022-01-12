using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terror_trigger_script : MonoBehaviour
{
    GameObject mob;
    int entered;

    void Start()
    {
        entered = 0;
        mob = GameObject.Find("mob_terror3");
        mob.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (entered == 0)
        {
            entered = 1;
            mob.SetActive(true);
            StartCoroutine(TimeLockedRemove(1, mob));
        }
    }

    void Update()
    {
        
    }

    IEnumerator TimeLockedRemove (int sec, GameObject obj)
    {
        yield return new WaitForSeconds(sec);
        obj.SetActive(false);
    }
}
