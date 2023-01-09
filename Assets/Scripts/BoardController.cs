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
    }

    public void applyMove(GameObject field, GameObject selector)
    {
        if (selector.gameObject.Equals(this.selector))
        {
            field.gameObject.GetComponent<MeshRenderer>().material = currentMat;
            field.gameObject.GetComponent<CollisionDetection>().setPlayer(playerSide);
            EndTurn();
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
}
