using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnManagerButton : MonoBehaviour
{
    public Button btn;
    public SpawnManager session;

    private void Start()
    {
        btn.onClick.AddListener(ChangePosVariable);
    }
    public void ChangePosVariable()
    {
        session.changePos = !session.changePos;
        if (session.changePos)
        {
            btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Stop Changing Position";
        }
        else
        {
            btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Change Position";
        }
    }
}
