using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DetectSelector : MonoBehaviour
{
    BoardController parent;
    public Material seethrough;

    private void Awake()
    {
        parent = GetComponentInParent<BoardController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detected collision with : " + other.gameObject.name);
        
        
        //parent.applyMove(this.gameObject, other.gameObject);
    }

    
}
