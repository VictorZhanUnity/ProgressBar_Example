using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// For 有進度條效果的按鈕使用
/// </summary>
[RequireComponent(typeof(ImageProgressBar), typeof(EventTrigger))]
public class ProgressBarEventTrigger : MonoBehaviour
{
    [SerializeField] private ImageProgressBar imageProgressBar;
    [SerializeField] private EventTrigger eventTrigger;
    [SerializeField] private bool IsAutoReverse = false;

    private bool keepUpdate = false;
    /// <summary>
    /// 是否受Script控制
    /// </summary>
    private bool m_IsActivated = false;
    public bool IsActivated
    {
        set { m_IsActivated = value; }
    }

    /// <summary>
    /// 是否受Click控制
    /// </summary>
    private bool m_IsPressDown = false;
    public bool IsPressDown
    {
        set { m_IsPressDown = value; }
    }

    private void Reset()
    {
        imageProgressBar = GetComponent<ImageProgressBar>();
        
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
       
        var pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        
        eventTrigger = GetComponent<EventTrigger>();
        eventTrigger.triggers.Add(pointerDown);
        eventTrigger.triggers.Add(pointerUp);
    }

    private void Update()
    {
        if (m_IsPressDown)
        {
            imageProgressBar.ProgressIncrease(true);
        }
        else
        {
            ControllByScript();
        }
    }

    private void ControllByScript()
    {
        if (!m_IsActivated)
        {
            imageProgressBar.ProgressDecrease();
            keepUpdate = true;
        }

        if (m_IsActivated)
        {
            imageProgressBar.ProgressIncrease();
            keepUpdate = false;
        }
        else
        {
            if (keepUpdate && IsAutoReverse)
            {
                imageProgressBar.ProgressDecrease();
            }
        }
    }

    public UnityAction<ImageProgressBar> onProgressComplete
    {
        get { return imageProgressBar.onProgressComplete; }
        set { imageProgressBar.onProgressComplete = value; }
    }

    /// <summary>
    /// 目前進度百分比
    /// </summary>
    public string CurrentProgress
    {
        get { return imageProgressBar.CurrentProgress; }
    }
}
