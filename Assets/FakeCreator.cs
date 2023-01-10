using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FakeCreator : MonoBehaviour
{
    public GameObject boardPrefab, selectorPrefab;
    private GameObject actualBoard, actualSelector;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            actualBoard = Instantiate(boardPrefab, this.transform);
            actualBoard.transform.position += new Vector3(0, -30, 0);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {

            actualSelector = Instantiate(selectorPrefab, this.transform);
            actualBoard.GetComponentInChildren<BoardController>().setSelector(actualSelector);
        }
    }

    //[Command(requiresAuthority = false)]
    //public void CmdSpawnBoard()
    //{
        
    //    NetworkServer.Spawn(actualBoard);
    //}

    //[ClientRpc]
    //public void RpcSpawnBoard()
    //{
    //    actualBoard = Instantiate(boardPrefab, this.transform);
    //    actualBoard.transform.position += new Vector3(0, -30, 0);
    //    CmdSpawnBoard();
    //}

    //[Command(requiresAuthority = false)]
    //public void CmdSpawnSelector()
    //{
       
    //    NetworkServer.Spawn(actualSelector);

    //}

    //[ClientRpc]
    //public void RpcSpawnSelector()
    //{
    //    actualSelector = Instantiate(selectorPrefab, this.transform);
    //    actualBoard.GetComponentInChildren<BoardController>().setSelector(actualSelector);
    //    CmdSpawnSelector();
    //}

    //[Command(requiresAuthority = false)]
    //public void CmdInstantiateBoard()
    //{
    //    RpcSpawnBoard();
    //}

    //[Command(requiresAuthority = false)]
    //public void CmdInstantiateSelector()
    //{
    //    RpcSpawnSelector();
    //}

}
