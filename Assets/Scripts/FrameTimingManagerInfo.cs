using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class FrameTimingManagerInfo : MonoBehaviour
{
    [SerializeField]
    private Text result;

    private FrameTiming[] frameTimings;
    private FrameTiming latest = new FrameTiming();
    private StringBuilder stringBuilder = new StringBuilder(128);
    private bool isFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        frameTimings = new FrameTiming[1];
    }


    // Update is called once per frame
    void Update()
    {
        FrameTimingManager.CaptureFrameTimings();
        var getFrames = FrameTimingManager.GetLatestTimings((uint)frameTimings.Length, frameTimings);

        if(getFrames > 0)
        {
            latest = frameTimings[0];
            if (isFirst)
            {
                ReloadInfo();
                isFirst = false;
            }
        }
    }

    public void ReloadInfo()
    {
        stringBuilder.Clear();
        stringBuilder.Append("cpuFrameTime:").Append(latest.cpuFrameTime).Append("\n");
        stringBuilder.Append("gpuFrameTime:").Append(latest.gpuFrameTime).Append("\n");
        stringBuilder.Append("syncInterval:").Append(latest.syncInterval).Append("\n");
        stringBuilder.Append("cpuTimeFrameComplete:").Append(latest.cpuTimeFrameComplete).Append("\n");
        stringBuilder.Append("cpuTimePresentCalled:").Append(latest.cpuTimePresentCalled).Append("\n");
        stringBuilder.Append("widthScale:").Append(latest.widthScale).Append("\n");
        stringBuilder.Append("heightScale:").Append(latest.heightScale).Append("\n");
        result.text = stringBuilder.ToString();
    }
}
