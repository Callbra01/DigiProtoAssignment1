using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Brandon Callaway
public class GhostCar : MonoBehaviour
{
    public static GhostCar instance { get; private set; }

    // Frame Data list
    List<DataFrame> frameDataList = new List<DataFrame>();

    public bool hasStarted = false;
    bool startTimer = false;

    // Timer related vars
    int timer = 0;
    int interval = 6;
    int currentFrame = 0;

    bool isTrackingPlayer = false;
    public float trackDistance = 6.9f;
    bool hasHitPlayer = false;

    Vector3 playerPosition = new Vector3();

    BoxCollider bCollider;

    private void Awake()
    {
        // Create instance if instance doesnt exist
        // Else replace instance with this
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Set interval to InputRecorders interval
    void Start()
    {
        interval = InputRecorder.instance.interval;
        bCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {

        // Load frame data, start timer if bool is checked - TODO: TOGGLE "hasStarted" WHEN PLAYER COMPLETES A LAP
        if (hasStarted)
        {
            frameDataList = InputRecorder.instance.loadedFrames;
            startTimer = true;
            hasStarted = false;
        }

        // If timer has started, update ghost car pos/rot data per interval
        if (startTimer)
        {
            IntervalUpdate();
        }
        //Debug.Log($"{playerPosition.x}, {playerPosition.y}");

        if (Vector3.Distance(transform.position, playerPosition) <= trackDistance && !hasHitPlayer)
        {
            isTrackingPlayer = true;
            transform.position = Vector3.Lerp(transform.position, playerPosition, 0.01f);
            if (new Vector3(transform.position.x, transform.position.y, 0f) == new Vector3(playerPosition.x, playerPosition.y, 0f))
            {
                hasHitPlayer = true;
            }
        }
        else
        {
            isTrackingPlayer = false;
        }

        if (hasHitPlayer)
        {
            isTrackingPlayer = false;
        }
        bCollider.enabled = isTrackingPlayer;
    }

    public void ReceivePlayerData(GameObject gObj)
    {
        playerPosition = gObj.transform.position;
    }

    void IntervalUpdate()
    {

        // Prevent index error
        if (currentFrame < frameDataList.Count && !isTrackingPlayer)
        {
            // Update pos/rot data for ghost car
            transform.position = frameDataList[currentFrame].position;
            transform.rotation = frameDataList[currentFrame].rotation;
        }

        // Every interval frame, update currentFrame to change pos/rot data for ghost car
        // Update "timer" every frame
        if (timer % interval == 0)
        {
            currentFrame++;
        }
        timer++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LapStart")
        {
            // Stop recording
        }
    }
}
