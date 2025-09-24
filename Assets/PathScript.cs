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

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoaded)
        {
            frameDataList = InputRecorder.instance.loadedFrames;

            PopulateFramePositions();


        }

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

    void PopulateFramePositions()
    {
        if (areFramesPopulated)
        {
            return;
        }


        for (int i = 0; i < frameDataList.Count; i += 6)
        {
            //if (i >= frameDataList.Count) break;

            framePositions.Add(frameDataList[i].position);
        }

        lineRenderer.positionCount = framePositions.Count;
        areFramesPopulated = true;
    }
}
