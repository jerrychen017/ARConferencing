using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedPrefab 
{
    public GameObject Prefab; 
    public string Path;

    public NetworkedPrefab(GameObject obj, string path) 
    {
        Prefab = obj; 
        Path = path; 
    }
}
