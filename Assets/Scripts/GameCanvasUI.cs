using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvasUI : MonoBehaviour
{
    public GameObject canvas;
    public GameObject btnRestart;
    public GameObject btnExit;

    public void UpdateUI()
    {
        float[] size = new float[2];
        size[0] = canvas.GetComponent<RectTransform>().rect.width;
        size[1] = canvas.GetComponent<RectTransform>().rect.height;

        btnRestart.GetComponent<RectTransform>().sizeDelta = new Vector2(size[0] / 1.5f, size[1] / 15);
        btnRestart.GetComponent<RectTransform>().position = new Vector3(size[0] / 2, (size[1] / 2) - btnRestart.GetComponent<RectTransform>().rect.height, 0);

        btnExit.GetComponent<RectTransform>().sizeDelta = new Vector2(size[0] / 1.5f, size[1] / 15);
        btnExit.GetComponent<RectTransform>().position = new Vector3(size[0] / 2, (size[1] / 2) - btnRestart.GetComponent<RectTransform>().rect.height * 2, 0);
    }
}
