using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOT NEEDED, REMOVE NEXT COMMIT
public class PlayerScript : MonoBehaviour
{

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LapTrigger")
        {
            Debug.Log("LAPPED");
            gameManager.isLapTriggerBlocked = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LapTrigger")
        {
            Debug.Log("ACTIVATE BLOCK");
            gameManager.isLapTriggerBlocked = true;
            gameManager.recorderInstance.TriggerProc();
            gameManager.TriggerPathHelper();
        }
    }
}
