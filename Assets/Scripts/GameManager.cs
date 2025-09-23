using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    InputRecorder recorderInstance;
    GhostCar ghostCarInstance;


    void Start()
    {
        recorderInstance = InputRecorder.instance;
        ghostCarInstance = GhostCar.instance;

    }


    void Update()
    {
        
    }
}
