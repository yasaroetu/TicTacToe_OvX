using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_ray;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField]

    public GameObject field;
    private GameObject spawnedField;
    public Canvas canPref;
    private Canvas can;

    private ARPlaneManager plane;

    private bool changePos = true;

    private Camera cam;

    private void Start()
    {

        cam = GameObject.Find("AR Camera").GetComponent<Camera>();
        plane = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();

        can = Instantiate(canPref);
        can.gameObject.SetActive(true);
        setupButton();
    }

    private void FixedUpdate()
    {
        if (!changePos)
        {
            PlaneActive(false);
            return;

        }
        if (Input.touchCount == 0) return;

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_ray.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (spawnedField != null)
                {
                    spawnedField.transform.position = m_Hits[0].pose.position;
                    changeMode();
                }
                else
                {
                    spawnedField = SpawnField(m_Hits[0].pose.position);
                    spawnedField.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
                    BoardController bc = spawnedField.GetComponentInChildren<BoardController>();
                    GameObject.Find("AR Session Origin").GetComponent<PlaceTrackedImages>().bc = bc;
                    changeMode();
                }
            }
        }

    }

    private GameObject SpawnField(Vector3 v)
    {
        return Instantiate(field, v, Quaternion.identity);
    }

    private void PlaneActive(bool value)
    {
        foreach (var plane in plane.trackables)
            plane.gameObject.SetActive(false);
    }
    void changeMode()
    {
        changePos = !changePos;
        // Menue führung kann noch geändert werden
        can.transform.GetChild(0).gameObject.SetActive(changePos);
        can.transform.GetChild(1).gameObject.SetActive(!changePos);

    }

    void setupButton()
    {
        Button btnSet = can.transform.GetChild(1).GetComponent<Button>();
        btnSet.onClick.AddListener(changeMode);

        //Position Set Button
        btnSet.image.rectTransform.sizeDelta = new Vector2(can.GetComponent<RectTransform>().rect.width, can.GetComponent<RectTransform>().rect.height / 20);
        btnSet.gameObject.transform.position = new Vector3((can.GetComponent<RectTransform>().rect.width / 2), (btnSet.GetComponent<RectTransform>().rect.height / 2), 0);
    }

    public Canvas getSpawnManagerCanvas() { return can; }
}