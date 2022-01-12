using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast_script : MonoBehaviour
{
    Vector3 CameraCenter;
    GameObject target;
    GameObject terror_mob;
    RaycastHit hit;
    int entered;
    // Start is called before the first frame update
    void Start()
    {
        entered = 0;
        terror_mob = GameObject.Find("mob_terror");
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

        if (target.name == "terror_container" && entered == 0)
        {
            entered = 1;
            StartCoroutine(TimeLockedRemove(2, terror_mob));
        }

    }

    IEnumerator TimeLockedRemove (int sec, GameObject obj)
    {
        yield return new WaitForSeconds(sec);
        obj.SetActive(false);
    }
}
