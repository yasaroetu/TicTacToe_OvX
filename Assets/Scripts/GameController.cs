using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameController : NetworkBehaviour
{

    [SerializeField]
    uint currentPlayer = 0;
    [SerializeField]
    uint currentTurn = 1;

    private void Awake()
    {
        Debug.Log("current player " + currentPlayer);
        Debug.Log("current turn " + currentTurn);
        currentPlayer = 0;
        currentTurn = 1;
    }

    public void switchTurn()
    {
        CmdSwitchTurn();
    }

    public void switchPlayer(uint player)
    {
        CmdSwitchPlayer(player);
    }

    public uint getCurrentTurn()
    {
        
        return currentTurn;
    }

    public uint getCurrentPlayer()
    {
        return currentPlayer;
    }

    public void printData()
    {
        Debug.Log("current player " + currentPlayer);
        Debug.Log("current turn " + currentTurn);

    }

    [Command(requiresAuthority = false)]
    public void CmdSwitchTurn()
    {
        RpcSwitchTurn();
    }


    [Command(requiresAuthority = false)]
    public void CmdSwitchPlayer(uint player)
    {
        RpcSwitchPlayer(player);
    }

    


    [ClientRpc]
    public void RpcSwitchTurn()
    {
        if (currentTurn == 1)
        {
            currentTurn = 2;
        }
        else
        {
            currentTurn = 1;
        }
    }

    [ClientRpc]
    public void RpcSwitchPlayer(uint player)
    {
        currentPlayer = player;
    }

}
