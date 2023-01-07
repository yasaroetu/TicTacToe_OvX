using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private GameObject[][] field;

    public Field(GameObject p, GameObject can, int size)
    {
        field = createField(p, can, size);
    }

    private GameObject[][] createField(GameObject p, GameObject can, int size)
    {
        GameObject[][] tmp = new GameObject[size][];
        for (int x = 0; x < size; x++)
        {
            tmp[x] = new GameObject[size];
            for (int y = 0; y < size; y++)
            {
                GameObject obj = Instantiate(p);
                obj.transform.SetParent(can.transform);
                tmp[x][y] = obj;

                float mWidth = p.GetComponent<RectTransform>().sizeDelta.x * size;
                float mHheight = p.GetComponent<RectTransform>().sizeDelta.y * size;


                // PROVISORISCH MUSS NOCH A BISEL GETESTET WERDEN
                Vector3 pos = new Vector3(
                    can.transform.position.x + ((mWidth - (p.GetComponent<RectTransform>().sizeDelta.x * size)) / 2) - (mWidth / 2) + (p.GetComponent<RectTransform>().sizeDelta.x / 2) + (x * p.GetComponent<RectTransform>().sizeDelta.x),
                    can.transform.position.y - (can.transform.position.y - (p.GetComponent<RectTransform>().sizeDelta.y * size) / 2) + (mHheight / 2) - (p.GetComponent<RectTransform>().sizeDelta.y / 2) - (y * p.GetComponent<RectTransform>().sizeDelta.y),
                    0f
                );

            }
        }
        return tmp;
    }

    public GameObject[][] getField() { return field; }
}


