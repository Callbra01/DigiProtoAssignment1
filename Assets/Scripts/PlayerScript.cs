using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOT NEEDED, REMOVE NEXT COMMIT
public class PlayerScript : MonoBehaviour
{
    GameManager gameManager;

    // Get gamemanager instance
    void Start()
    {
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If player enters lap trigger, disable backwards trigger block
        if (other.gameObject.tag == "LapTrigger")
        {
            gameManager.isLapTriggerBlocked = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If player leaves lap trigger, enable backwards trigger block
        // alongside this, trigger recorder trigger function and pathhelper trigger function
        if (other.gameObject.tag == "LapTrigger")
        {
            gameManager.LapTriggerFunction();
        }
    }
}
