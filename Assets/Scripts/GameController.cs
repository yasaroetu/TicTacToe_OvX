using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameController : NetworkBehaviour
{
    [SyncVar]
    uint lastMove;
    public int fieldToSwitch;


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

    public void restartGame()
    {
        CmdRestartGame();
    }

    [Command(requiresAuthority = false)]
    public void CmdRestartGame()
    {
        RpcRestartGame();
    }

    [ClientRpc]
    public void RpcRestartGame()
    {
        BoardController board = GameObject.Find("Board(Clone)").GetComponentInChildren<BoardController>();
        board.restartGame();
    }
    
}
