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
}
