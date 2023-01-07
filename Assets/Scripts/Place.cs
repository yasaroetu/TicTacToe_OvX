using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    private Player p;
    private GameObject field;

    public Place(Player p,GameObject field)
    {
        this.p = p;
        this.field = field;
    }

    public GameObject placeObject(GameObject target)
    {
        GameObject obj = Instantiate(p.getObj(), field.GetComponent<Transform>().position,Quaternion.identity);
        obj.transform.position = target.transform.position;
        Destroy(target);

        return obj;
    }

}
