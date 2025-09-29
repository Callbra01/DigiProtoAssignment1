using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance {  get; private set; }

    public InputRecorder recorderInstance;
    GhostCar ghostCarInstance;
    PlayerScript playerScript;
    public PathScript pathHelper;

    public GameObject playerObject;
    public GameObject triggerBlockObject;

    public bool isLapTriggerBlocked = true;

    int currentLap = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        currentLap = 0; 

        recorderInstance = InputRecorder.instance;
        ghostCarInstance = GhostCar.instance;
        playerScript = playerObject.GetComponent<PlayerScript>();
        triggerBlockObject = GameObject.FindGameObjectWithTag("LapTriggerBlock");
        pathHelper = GameObject.Find("Pathhelper").GetComponent<PathScript>();
    }


    void Update()
    {
        triggerBlockObject.SetActive(isLapTriggerBlocked);

        ghostCarInstance.ReceivePlayerData(playerObject);
    }

    public void TriggerPathHelper()
    {
        pathHelper.isLoaded = true;
    }

    public void ResetPathHelper()
    {
        pathHelper.ResetPath();
    }

    // Called by player script when player crosses lap trigger
    public void LapTriggerFunction()
    {
        if (currentLap == 0)
        {
            isLapTriggerBlocked = true;
            recorderInstance.TriggerProc();
            TriggerPathHelper();
            ghostCarInstance.hasStarted = true;
            currentLap++;
            return;
        }
        else
        {
            ResetLap();
        }

    }

    public void ResetLap()
    {
        recorderInstance.RestartRecording();
        ResetPathHelper();
    }
}
