using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject obj; // X oder O prefab

    private string n;

    public Player(string name,GameObject obj)
    {
        this.n = name;
        this.obj = obj;
    }
    public string getName() { return this.n; }
    public GameObject getObj () { return this.obj; }

}

