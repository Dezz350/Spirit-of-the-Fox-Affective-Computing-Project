using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast_script_disturb1 : MonoBehaviour
{
    Vector3 CameraCenter;
    GameObject target;
    GameObject terror_mob;
    GameObject terror_mob2;
    RaycastHit hit;
    int entered1;
    int entered2;
    // Start is called before the first frame update
    void Start()
    {
        entered1 = 0;
        entered2 = 0;
        terror_mob = GameObject.Find("mob_terror");
        terror_mob2 = GameObject.Find("mob_terror1");
    }

    // Update is called once per frame
    void Update()
    {
        CameraCenter = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width/2f, Screen.height/2f, GetComponent<Camera>().nearClipPlane));
        if (Physics.Raycast(CameraCenter, transform.forward, out hit, 1000))
        {
            target = hit.transform.gameObject;
            //Debug.Log(target.name);
        }

        if (target.name == "terror_container" && entered1 == 0 && terror_mob.activeInHierarchy)
        {
            entered1 = 1;
            StartCoroutine(TimeLockedRemove(2, terror_mob));
        }

        if (target.name == "terror_container1" && entered2 == 0)
        {
            entered2 = 1;
            StartCoroutine(TimeLockedRemove(2, terror_mob2));
        }

    }

    IEnumerator TimeLockedRemove (int sec, GameObject obj)
    {
        yield return new WaitForSeconds(sec);
        obj.SetActive(false);
    }
}
