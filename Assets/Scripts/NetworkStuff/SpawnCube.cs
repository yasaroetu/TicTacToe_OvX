using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnCube : NetworkBehaviour
{

    public Material X_Mat;
    public Material O_Mat;

    public GameObject[] playFields;
    

    public GameObject selector;
    public GameController controller;

    uint myPlayer;

    

    [Command(requiresAuthority =false)]
    public void CMDSetPlayer()
    {
        RPCSetPlayer();
    }


    [ClientRpc]
    public void RPCSetPlayer()
    {
        myPlayer = NetworkClient.localPlayer.netId;
        Debug.Log(myPlayer);
    }

    public void applyMove(GameObject field, GameObject selector)
    {
        if (selector.gameObject.Equals(this.selector)){

            Debug.Log(" i am player : " + NetworkClient.localPlayer.netId);

            //if(controller.getCurrentPlayer() == NetworkClient.localPlayer.netId)
            //{
            //    return;
            //}
            //else
            {
                //Debug.Log("change Mat");
                //Debug.Log("current player from controller " + controller.getCurrentPlayer());
                //Debug.Log("current turn from controller " + controller.getCurrentTurn());

                ////if (controller.getCurrentTurn() == 1)
                //{
                //    field.gameObject.GetComponent<MeshRenderer>().material = X_Mat;
                //    controller.switchTurn();
                //    controller.switchPlayer(NetworkClient.localPlayer.netId);
                //}

                ////if (controller.getCurrentTurn() == 2)
                //{
                //    field.gameObject.GetComponent<MeshRenderer>().material = O_Mat;
                //    controller.switchTurn();
                //    controller.switchPlayer(NetworkClient.localPlayer.netId);
                //}

                //controller.printData();
            }

            


            
        }
        
    }

    

    

    
}
