using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;


public class HostConnect : MonoBehaviour
{
    NetworkManager manager;
    public TMP_InputField ip_inputField;
    public GameObject HostConnect_go;



    // Start is called before the first frame update
    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    public void HostFunction()
    {
        manager.StartHost();

        HostConnect_go.SetActive(false);
    }

    public void ConnectFunction()
    {
        manager.networkAddress = ip_inputField.text;
        manager.StartClient();

        HostConnect_go.SetActive(false);
    }

}
