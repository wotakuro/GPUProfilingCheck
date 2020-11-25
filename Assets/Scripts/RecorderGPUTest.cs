using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;

public class RecorderGPUTest : MonoBehaviour
{
    [SerializeField]
    private Text isSupportGpuRecorder;

    private Recorder recordCameraRender;

    // Start is called before the first frame update
    void Start()
    {
        isSupportGpuRecorder.text = "supportGPURecorder:"+SystemInfo.supportsGpuRecorder;

        recordCameraRender = Recorder.Get("Camera.Render");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(
        recordCameraRender.gpuElapsedNanoseconds);
    }
}
