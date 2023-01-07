using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelectorScript : MonoBehaviour
{
    Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            myTransform.position = new Vector3(myTransform.position.x, myTransform.position.y+10, myTransform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            myTransform.position = new Vector3(myTransform.position.x, myTransform.position.y - 10, myTransform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            myTransform.position = new Vector3(myTransform.position.x -10, myTransform.position.y, myTransform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            myTransform.position = new Vector3(myTransform.position.x +10, myTransform.position.y, myTransform.position.z);
        }
    }
}
