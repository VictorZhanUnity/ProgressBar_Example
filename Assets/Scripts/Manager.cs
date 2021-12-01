using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [Header("Key Codes")]
    [SerializeField] private KeyCode selectKey = KeyCode.Mouse0;

    private bool shouldUpdate = false;

    [SerializeField] private Text txtProgress;
    [SerializeField] private ImageProgressBar radialProgressBar;

    private void Start()
    {
        radialProgressBar.onProgressComplete += OnProgressComplete;
    }

    private void Update()
    {
        txtProgress.text = $"<size=100`>{radialProgressBar.CurrentProgress}</size>%";
        if (Input.GetKey(selectKey))
        {
            radialProgressBar.ProgressIncrease();
            shouldUpdate = false;
        }
        else
        {
            if (shouldUpdate)
            {
                radialProgressBar.ProgressDecrease();
            }
        }
        if (Input.GetKeyUp(selectKey))
        {
            radialProgressBar.ProgressDecrease();
            shouldUpdate = true;
        }
    }

    public void OnProgressComplete(ImageProgressBar progressBar)
    {
        Debug.Log("Manager.OnProgressComplete: " + progressBar.CurrentProgress);
    }
}
