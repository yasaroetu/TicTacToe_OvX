using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSelector : MonoBehaviour
{
    SpawnCube parent;

    private void Awake()
    {
        parent = GetComponentInParent<SpawnCube>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detected collision with : " + other.gameObject.name);
        
        
        parent.applyMove(this.gameObject, other.gameObject);
    }
}
