using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_ray;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField]

    public GameObject field;
    private GameObject spawnedField;
    public Button btn;

    private ARPlaneManager plane;

    public bool changePos = false;

    private Camera cam;

    private void Start()
    {
        cam = GameObject.Find("AR Camera").GetComponent<Camera>();
        plane = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();

        // Menue führung kann noch geändert werden
        SpawnManagerButton btnM = btn.transform.gameObject.AddComponent(typeof(SpawnManagerButton)) as SpawnManagerButton;
        btnM.btn = btn;
        btnM.session = this;
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
                }
                else
                {
                    spawnedField = SpawnField(m_Hits[0].pose.position);
                    spawnedField.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
                    BoardController bc = spawnedField.GetComponentInChildren<BoardController>();
                    GameObject.Find("AR Session Origin").GetComponent<PlaceTrackedImages>().bc = bc;
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
}