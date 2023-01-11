using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    
    public void OnClickPlayOnline()
    {
        SceneManager.LoadScene("BlankAR 1");
    }

    public void OnClickPlayLocal()
    {
        SceneManager.LoadScene("BlankAR");
    }


}
