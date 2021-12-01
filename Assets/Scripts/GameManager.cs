using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text txtProgress;
    [SerializeField] private ProgressBarEventTrigger progressBarEventTrigger;

    private void Start()
    {
        progressBarEventTrigger.onProgressComplete += OnProgressComplete;
    }

    private void Update()
    {
        txtProgress.text = $"<size=100>{progressBarEventTrigger.CurrentProgress}</size>%";
        InputHandler();
    }

    private void InputHandler()
    {
        if (Input.GetKey(KeyCode.P)) progressBarEventTrigger.IsActivated = true;
        else if (Input.GetKeyUp(KeyCode.P)) progressBarEventTrigger.IsActivated = false;
    }

    public void OnProgressComplete(ImageProgressBar progressBar)
    {
        Debug.Log("Manager.OnProgressComplete: " + progressBar.CurrentProgress);
    }
}
