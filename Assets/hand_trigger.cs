using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand_trigger : MonoBehaviour
{
    GameObject hand;
    GameObject fox;
    GameObject target_final;
    Vector3 target;
    Animator hand_anim;
    int limit;
    int move_limit;

    void Start()
    {
        hand = GameObject.Find("hand_terror");
        target_final = GameObject.Find("fox_target_final");
        target = target_final.transform.position;
        fox = GameObject.Find("fox_npc");
        limit = 1;
        move_limit = 1;
        hand_anim = hand.GetComponent <Animator> ();
    }

    void OnTriggerEnter(Collider other)
    { 
        PersistentManager.Instance.GetComponent<AudioSource>().Stop();
        if (limit == 1)
        {
            limit = 0;
            hand_anim.SetBool("grab_state", true);
            hand_anim.Play("GRAB");
        }
    }

    void Update()
    {
        if (limit == 0)
        {
            StartCoroutine(TimeLockedMovement(1, fox));
            //fox.transform.position = Vector3.Lerp(fox.transform.position, target, Time.deltaTime*1f);
        }
    }
    
    IEnumerator TimeLockedMovement(int sec, GameObject obj)
    {
        yield return new WaitForSeconds(sec);
        obj.transform.position = Vector3.Lerp(obj.transform.position, target, Time.deltaTime*1f);
    }

}
