using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text txtProgress;
    [SerializeField] private ProgressBarEventTrigger progressUp;
    [SerializeField] private ProgressBarEventTrigger progressDown;

    private void Start()
    {
        progressUp.onProgressComplete += OnProgressComplete;
        progressDown.onProgressComplete += OnProgressComplete;
    }

    private void Update()
    {
        txtProgress.text = $"<size=100>{progressUp.CurrentProgress}</size>%";
        InputHandler();
    }

    private void InputHandler()
    {
        if (Input.GetKey(KeyCode.P)) progressUp.IsActivated = true;
        else if (Input.GetKeyUp(KeyCode.P)) progressUp.IsActivated = false;
        else if (Input.GetKey(KeyCode.L)) progressDown.IsActivated = true;
        else if (Input.GetKeyUp(KeyCode.L)) progressDown.IsActivated = false;
    }

    public void OnProgressComplete(ImageProgressBar progressBar)
    {
        Debug.Log("Manager.OnProgressComplete: " + progressBar.name);
    }
}
