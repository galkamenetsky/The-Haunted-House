using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SkipTimeLine : MonoBehaviour
{
    public PlayableDirector timeline;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SkipTimeline();
    }
    private void SkipTimeline()
    {
        if (timeline != null)
        {
            timeline.time = timeline.duration;
            timeline.Evaluate();
        }
    }
}
