using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecorderGPUTest : MonoBehaviour
{
    [SerializeField]
    private Text isSupportGpuRecorder;
    // Start is called before the first frame update
    void Start()
    {
        isSupportGpuRecorder.text = "supportGPURecorder:"+SystemInfo.supportsGpuRecorder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
