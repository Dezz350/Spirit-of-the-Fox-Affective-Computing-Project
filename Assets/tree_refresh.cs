using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_refresh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Terrain>().terrainData.RefreshPrototypes();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Terrain>().terrainData.RefreshPrototypes();
    }
}
