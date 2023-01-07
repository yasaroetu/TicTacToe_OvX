using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Watcher : MonoBehaviour
{
    public GameObject xObject;
    public GameObject oObject;
    public GameObject pattern;

    public int size = 1;

    private Player pX;
    private Player pY;
    private Field field;

    public Watcher(int size)
    {
        this.size = size;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject can = GameObject.Find("Canvas");
        pX = new Player("Player 1", xObject);
        pY = new Player("Player 2", oObject);
        

        // 3x3
        field = new Field(pattern, can, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private Player WinCondition(Field f)
    {
        GameObject[][] field = f.getField();
        GameObject[] conTwo = new GameObject[field[0].Length]; // Y ACHSEN CHECK
        GameObject[] conThree = new GameObject[field.Length < field[0].Length ? field.Length : field[0].Length]; // SENKRECHT VON LINKS NACH UNTEN RECHTS
        GameObject[] conFour = new GameObject[field.Length < field[0].Length ? field.Length : field[0].Length]; // SENKRECHT VON RECHTS NACH UNTEN LINKS

        int counterX = field.Length-1;
        int counterY = 0;

        for (int x = 0; x < field.Length; x++)
        {
            for(int y = 0; y < field[x].Length; y++ )
            {
                conTwo[y] = field[x][y].transform.GetChild(0).gameObject;
                if(x == y)
                {
                    conThree[x] = field[x][y].transform.GetChild(0).gameObject;
                }
                if(counterX == x && counterY == y)
                {
                    counterX -= 1;
                    counterY += 1;
                    conFour[x] = field[x][y].transform.GetChild(0).gameObject;
                }
            }
        }

        //CHECK IF SOMEONE WON
        GameObject tmp = null;
        Player winner = null;
        for(int y = 0; y < field[0].Length; y++)
        {
            for (int x = 0; x < field.Length; x++) {
                if (x == 0)
                {
                    tmp = field[x][y].transform.GetChild(0).gameObject;
                }
                else
                {
                    if(tmp.transform.name != field[x][y].transform.GetChild(0).gameObject.transform.name)
                    {
                        break;
                    }
                }

                if(x == field.Length-1)
                {
                    winner = getPlayer(tmp);
                }
            }

            if(winner != null) { return winner; }
        }


        Player checkFunction(GameObject[] arr) {
            GameObject tmp = arr[0];
            Player winner = getPlayer(arr[0]);
            for (int i = 0; i < arr.Length; i++)
            {
                if(tmp != arr[i])
                {
                    return null;
                }
            }
            return winner;
        }

        winner = checkFunction(conTwo);
        if (winner != null) return winner;
        winner = checkFunction(conThree);
        if (winner != null) return winner;
        winner = checkFunction(conFour);
        if (winner != null) return winner;

        return null;
    }*/

    public Player getPlayer(GameObject obj)
    {
        return obj.transform.name == pX.getObj().transform.name ? pX : pY;
    }
}
