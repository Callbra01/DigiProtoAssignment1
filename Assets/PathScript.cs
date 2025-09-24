using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    LineRenderer lineRenderer;

    public static PathScript instance { get; private set; }

    public bool isLoaded = false;
    bool areFramesPopulated = false;

    bool isLineDrawn = false;

    List<DataFrame> frameDataList = new List<DataFrame>();
    List<Vector3> framePositions = new List<Vector3>();
    Vector3[] framePositionsV;

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

    // Get LineRenderer component
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // If pathhelper is triggered (specifically after current lap frames have been save to file)
        // load inputRecorder loaded frames, and populate private frame position array
        if (isLoaded)
        {
            frameDataList = InputRecorder.instance.loadedFrames;

            PopulateFramePositions();
        }

        // When private frame position array is populated, and valid, set positions for line renderer ONCE
        if (areFramesPopulated  && !isLineDrawn && framePositions.Count > 2)
        {
            for (int i = 0; i < framePositions.Count; i ++)
            {
                lineRenderer.SetPositions(framePositions.ToArray());
                //lineRenderer.SetPosition(i, framePositions[i]);
            }
            isLineDrawn = true;
        }
    }

    // Populate private frame position array
    void PopulateFramePositions()
    {
        // If frames are populated, return from func
        if (areFramesPopulated)
        {
            return;
        }

        // If frames are not populated, loop through and visualize every 1 second of frame data, for brevity
        for (int i = 0; i < frameDataList.Count; i += 6)
        {
            framePositions.Add(frameDataList[i].position);
        }

        // Set lineRenderer position count to the amount of frames we have, and disable this func
        lineRenderer.positionCount = framePositions.Count;
        areFramesPopulated = true;
    }
}
