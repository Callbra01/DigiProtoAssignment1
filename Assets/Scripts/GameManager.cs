using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    InputRecorder recorderInstance;
    GhostCar ghostCarInstance;

    GameObject playerObject;

    void Start()
    {
        recorderInstance = InputRecorder.instance;
        ghostCarInstance = GhostCar.instance;

    }


    void Update()
    {
        ghostCarInstance.ReceivePlayerData(playerObject);
    }
}
