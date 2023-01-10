using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{
    public Material X_Mat;
    public Material O_Mat;
    private Material currentMat;

    public GameObject[] playFields;
    public GameObject playFieldPrefab;
    //[SyncVar]
    public GameObject currentField;

    private GameObject selector;

    private string playerSide;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;
    private int moveCount;
    private string[] fieldList = new string[9];
    


    private void Awake()
    {
        playerSide = "X";
        moveCount = 0;
        currentMat = X_Mat;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        
        //CmdSpawnFields();
    }

    public void applyMove(int indexOfField)
    {
        Debug.Log("Board: the field i have to swap is : " + indexOfField);
        playFields[indexOfField].gameObject.GetComponent<MeshRenderer>().material = currentMat;
        playFields[indexOfField].gameObject.GetComponent<CollisionDetection>().setPlayer(playerSide);
        EndTurn();

    }

    public void startSelection(GameObject field, GameObject selector)
    {
        if (selector.gameObject.Equals(this.selector))
        {
            Debug.Log("starting selection");
            int index = findFieldInArray(field);
            Debug.Log("found field index : " + index);
            GameController controller = GameObject.Find("GameController").GetComponent<GameController>();
            controller.setFieldToSwitch(index);
        }
    }


    public void EndTurn()
    {
        moveCount++;


        if (playFields[0].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[1].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[2].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide)
        {
            GameOver(playerSide);
        }
        if (playFields[3].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[4].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[5].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide)
        {
            GameOver(playerSide);
        }
        if (playFields[6].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[7].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[8].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide)
        {
            GameOver(playerSide);
        }


        if (playFields[0].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[3].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[6].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide)
        {
            GameOver(playerSide);
        }
        if (playFields[1].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[4].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[7].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide)
        {
            GameOver(playerSide);
        }
        if (playFields[2].gameObject.GetComponent<CollisionDetection>().getPlayer()  == playerSide && playFields[5].gameObject.GetComponent<CollisionDetection>().getPlayer()  == playerSide && playFields[8].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide)
        {
            GameOver(playerSide);
        }


        if (playFields[0].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[4].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[8].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide)
        {
            GameOver(playerSide);
        }
        if (playFields[2].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[4].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide && playFields[6].gameObject.GetComponent<CollisionDetection>().getPlayer() == playerSide)
        {
            GameOver(playerSide);
        }


        if (moveCount >= 9)
        {
            Debug.Log("Mehr als 9 züge");
            GameOver("draw");
        }
        SwitchSide();
    }

    void GameOver(string winner)
    {
        //setBoardInteractable(false);

        if (winner == "draw")
        {
            Debug.Log("es war ein unentschieden");
            setGameOverText("Unentschieden! gg");
        }
        else
        {
            setGameOverText(playerSide + " hat gewonnen! ");
        }

        restartButton.SetActive(true);
    }

    void SwitchSide()
    {
        if (playerSide == "X")
        {
            playerSide = "O";
            currentMat = O_Mat;
        }
        else
        {
            playerSide = "X";
            currentMat = X_Mat;
        }
    }

    void setGameOverText(string words)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = words;
    }

    public void restart()
    {
        GameController controller = GameObject.Find("GameController").GetComponent<GameController>();
        controller.restartGame();
    }


    public void restartGame()
    {
        Debug.Log("Button pressed");
        playerSide = "X";
        currentMat = X_Mat;
        moveCount = 0;
        gameOverPanel.SetActive(false);

        for (int i = 0; i < playFields.Length; i++)
        {
            playFields[i].GetComponent<CollisionDetection>().ResetGame();
        }
        restartButton.SetActive(false);
    }

    public void setSelector(GameObject sel)
    {
        this.selector = sel;
    }


    private int findFieldInArray(GameObject field)
    {
        int fieldNumber = 0;
        for(int i = 0; i<playFields.Length; i++)
        {
            if(playFields[i] == field)
            {
                fieldNumber = i;
                break;
            }
        }
        return fieldNumber;
    }

    //[Command(requiresAuthority = false)]
    //public void CmdApplyMove( GameObject selector)
    //{
    //    RpcApplyMove(selector);
    //}

    //[ClientRpc]
    //public void RpcApplyMove( GameObject selector)
    //{
    //    currentField.gameObject.GetComponent<MeshRenderer>().material = currentMat;
    //    currentField.gameObject.GetComponent<CollisionDetection>().setPlayer(playerSide);
    //    EndTurn();
    //}

    //[Command(requiresAuthority = false)]
    //public void CmdSpawnFields()
    //{
    //    var field = Instantiate(playFieldPrefab);
    //    playFields[0] = field;
    //    field.transform.position += new Vector3(-20, 20, 0);
    //    NetworkServer.Spawn(field);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[1] = field;
    //    field.transform.position += new Vector3(0, 20, 0);
    //    NetworkServer.Spawn(field);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[2] = field;
    //    field.transform.position += new Vector3(20, 20, 0);
    //    NetworkServer.Spawn(field);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[3] = field;
    //    field.transform.position += new Vector3(-20, 0, 0);
    //    NetworkServer.Spawn(field);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[4] = field;
    //    field.transform.position += new Vector3(0, 0, 0);
    //    NetworkServer.Spawn(field);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[5] = field;
    //    field.transform.position += new Vector3(20, 0, 0);
    //    NetworkServer.Spawn(field);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[6] = field;
    //    field.transform.position += new Vector3(-20, -20, 0);
    //    NetworkServer.Spawn(field);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[7] = field;
    //    field.transform.position += new Vector3(0, -20, 0);
    //    NetworkServer.Spawn(field);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[8] = field;
    //    field.transform.position += new Vector3(20, -20, 0);
    //    NetworkServer.Spawn(field);


    //    foreach (GameObject item in playFields)
    //    {
    //        NetworkServer.Spawn(item);
    //    }
    //}

    //[ClientRpc]
    //public void RpcSpawnFields()
    //{
    //    var field = Instantiate(playFieldPrefab);
    //    playFields[0] = field;
    //    field.transform.position += new Vector3(-20, 20, 0);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[1] = field;
    //    field.transform.position += new Vector3(0, 20, 0);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[2] = field;
    //    field.transform.position += new Vector3(20, 20, 0);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[3] = field;
    //    field.transform.position += new Vector3(-20, 0, 0);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[4] = field;
    //    field.transform.position += new Vector3(0, 0, 0);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[5] = field;
    //    field.transform.position += new Vector3(20, 0, 0);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[6] = field;
    //    field.transform.position += new Vector3(-20, -20, 0);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[7] = field;
    //    field.transform.position += new Vector3(0, -20, 0);
    //    field = Instantiate(playFieldPrefab);
    //    playFields[8] = field;
    //    field.transform.position += new Vector3(20, -20, 0);


    //}

    //[Command(requiresAuthority = false)]
    //public void CmdSpawn()
    //{
    //    foreach(GameObject field in playFields)
    //    {
    //        NetworkServer.Spawn(field);
    //    }
    //}

    //[Command(requiresAuthority = false)]
    //public void CmdSetCurrentField(GameObject field)
    //{
    //    currentField = field;
    //}
}
