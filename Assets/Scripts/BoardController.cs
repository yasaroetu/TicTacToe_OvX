using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject btnExit;
    private int moveCount;
    private bool lock_interaction = false;
    


    private void Awake()
    {
        playerSide = "X";
        moveCount = 0;
        currentMat = X_Mat;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        btnExit.SetActive(false);

        // EXIT BUTTON BEARBEITEN
        btnExit.GetComponent<Button>().onClick.AddListener(SwitchToMainMenue);
        
        GameCanvasUI gcui = GameObject.Find("GameCanvas").GetComponent<GameCanvasUI>();
        gcui.UpdateUI();
    }

    public void applyMove(int indexOfField)
    {
        if (lock_interaction) return;
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
            Debug.Log("Mehr als 9 z�ge");
            GameOver("draw");
        }
        SwitchSide();
    }

    void GameOver(string winner)
    {
        //setBoardInteractable(false);
        lock_interaction = true;
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
        btnExit.SetActive(true);
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
        btnExit.SetActive(false);
        lock_interaction = false;
        GameObject.Find("AR Session Origin").GetComponent<SpawnManager>().getSpawnManagerCanvas().gameObject.SetActive(true);
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

    private void SwitchToMainMenue()
    {
        SceneManager.LoadScene("GameStart");
    }
}
