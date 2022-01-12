using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terror_shake_script : MonoBehaviour
{
    GameObject terror_shake;
    int derange;

    void Start()
    {
        terror_shake = this.gameObject;
        derange = 0;

        StartCoroutine(TimeLockedVibration(0.1f, terror_shake));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TimeLockedVibration(float sec, GameObject obj)
    {
        while(true)
        {
            yield return new WaitForSeconds(sec);
            if (derange == 0)
            {
                obj.transform.localPosition = new Vector3(Random.Range(-0.3f,0.3f),Random.Range(-0.3f,0.3f),Random.Range(-0.3f,0.3f));
                derange = 1;
            }
            else
            {
                obj.transform.localPosition = new Vector3(0,0,0);
                derange = 0;
            }
        }
    }
}
