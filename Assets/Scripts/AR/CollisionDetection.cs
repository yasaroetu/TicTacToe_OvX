using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class CollisionDetection : MonoBehaviour
{
    private bool place = false;
    private int counter = 0;
    private bool left = true;
    private GameObject pref;

    private void OnTriggerEnter(Collider other)
    {
        left = false;
        startTimer();
    }

    private void OnTriggerStay(Collider other)
    {
        if (place)
        {
            place = false;
            counter = 0;

            /**** V HIER DER CODE ZUR AUSFÜHRUNG DER INTERAKTION V ****/

            // MUSS GLAUBE NOCH BEARBEITET WERDEN HABE NOCH NICHTS GETESTET
            Place p = new Place(pref.GetComponent<Player>(), pref.GetComponent<Player>().getObj());
            p.placeObject(other.gameObject);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        left = true;
    }

    private void startTimer()
    {
        if (counter == 0)
        {
            sleeper();
        }
        else
        {
            counter = 0;
        }
    }

    private async void sleeper()
    {
        while (counter != 3000)
        {
            await Task.Delay(1);
            if (left)
                break;
            counter++;
        }
        if (left)
        {
            left = false;
            return;
        }
        place = true;
    }
}
