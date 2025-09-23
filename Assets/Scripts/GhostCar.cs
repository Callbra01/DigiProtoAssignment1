using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Brandon Callaway
// To be added on whatever game object that represents the ghost car
// TODO: CREATE BEHAVIOR FOR INTERACTING WITH THE PLAYER - WHILST MAINTAINING THE CORRECT FRAME INTERVAL POS/ROT DATA
// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ HARD PART
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

    bool isAttacking = false;

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
    }

    void IntervalUpdate()
    {
        // Prevent index error
        if (currentFrame < frameDataList.Count)
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
