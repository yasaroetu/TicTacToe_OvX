using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameController : NetworkBehaviour
{
    [SyncVar]
    uint lastMove;
    public int fieldToSwitch;

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


    public void setFieldToSwitch(int field)
    {
        if (lastMove != NetworkClient.localPlayer.netId) CmdSetFieldToSwitch(field, NetworkClient.localPlayer.netId);
        else Debug.Log("Not your turn");
        
        
        
    }

    [Command(requiresAuthority = false)]
    public void CmdSetFieldToSwitch(int field, uint playerid)
    {
        lastMove = playerid;
        RpcSetFieldToSwitch(field);
    }

    [ClientRpc]
    public void RpcSetFieldToSwitch(int field)
    {
        fieldToSwitch = field;
        Debug.Log("Controller : the field u have to swap is = " + fieldToSwitch);
        Debug.Log("Client : change field");
        BoardController board = GameObject.Find("Board(Clone)").GetComponentInChildren<BoardController>();
        Debug.Log("Client : Found the board! : " + board);
        board.applyMove(fieldToSwitch);
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeField()
    {
        Debug.Log("Server : change field");
        RpcChangeField();
    }

    [ClientRpc]
    public void RpcChangeField()
    {

        Debug.Log("Client : change field");
        BoardController board = GameObject.Find("Board(Clone)").GetComponentInChildren<BoardController>();
        Debug.Log("Client : Found the board! : " + board);
        board.applyMove(fieldToSwitch);
    }

    
}
