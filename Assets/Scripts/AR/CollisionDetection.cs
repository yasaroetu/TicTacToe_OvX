using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class CollisionDetection : MonoBehaviour
{
    private float elapsed = 0;
    private bool filled = false;
    public Material seethrough;
    private string player; 


    BoardController parent;

    private void Awake()
    {
        parent = GetComponentInParent<BoardController>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (!filled)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 2)
            {
                parent.startSelection(this.gameObject, other.gameObject);
                Debug.Log("Placed");
                elapsed = 0;
                filled = true;
            }
        }
        
    }

    public string getPlayer()
    {
        return player;
    }

    public void setPlayer(string player)
    {
        this.player = player;
    }

    public void ResetGame()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = seethrough;
        filled = false;
        player = "";
    }
}
