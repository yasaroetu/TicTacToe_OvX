using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class UIHandler : NetworkBehaviour
{
    public TextMeshProUGUI text;
    uint currentPlayer;

    public void OnClickGet()
    {
        
        RpcCurrPlayer(currentPlayer);
    }

    public void OnClickLeft()
    {
        uint netId = NetworkClient.localPlayer.netId;

        if(currentPlayer == netId)
        {
            Debug.Log("It's not your turn!");
            text.text = "Player " + netId + "! It's not your turn";
            return;
        }

        Debug.Log("OnClickLeft netId: " + netId);

        CmdPickLeft(netId);
    }
    public void OnClickRight()
    {


        uint netId = NetworkClient.localPlayer.netId;

        if (currentPlayer == netId)
        {
            Debug.Log("It's not your turn!");
            text.text = "Player " + netId + "! It's not your turn";
            return;
        }

        Debug.Log("OnClickRight netId: " + netId);

        CmdPickRight(netId);
    }

    [Command(requiresAuthority = false)]
    public void CmdPickLeft(uint netId)
    {
        Debug.Log("CmdPickLeft netId: " + netId);
        
        RpcPickLeft(netId);
    }

    [Command(requiresAuthority = false)]
    public void CmdPickRight(uint netId)
    {
        Debug.Log("CmdPickRight netId: " + netId);
        
        RpcPickRight(netId);
    }

    [Command(requiresAuthority = false)]
    public void CmdCurrPlayer(uint netid)
    {
        RpcCurrPlayer(netid);
    }

    [ClientRpc]
    public void RpcCurrPlayer(uint netid)
    {
        text.text = "Current Player " + netid;
    }

    [ClientRpc]
    public void RpcPickLeft(uint netId)
    {
        Debug.Log("RpcPickLeft netId: " + netId);
        text.text = "Player " + netId + " picked left";
        currentPlayer = netId;
    }

    [ClientRpc]
    public void RpcPickRight(uint netId)
    {
        Debug.Log("RpcPickRight netId: " + netId);
        text.text = "Player " + netId + " picked right";
        currentPlayer = netId;
    }

    
}
