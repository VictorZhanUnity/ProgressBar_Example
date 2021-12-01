using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// ��n���Image��b�P�@��GameObject���U
/// </summary>
[RequireComponent(typeof(Image))]
public class ImageProgressBar : MonoBehaviour
{
    [Header("Radial Timers")]
    [SerializeField] private float indicatorTimer = 0f;
    [SerializeField] private float maxIndicatorTimer = 1.0f;
    [Header("UI Indicator")]
    [SerializeField] private Image ImageUI = null;

    public UnityAction<ImageProgressBar> onProgressComplete = null;
    public UnityAction<ImageProgressBar> onProgressToStart = null;

    /// <summary>
    /// �]�mTimer�̤j���
    /// </summary>
    public float MaxIndicatorTimer
    {
        set { maxIndicatorTimer = value; }
    }


    private void Start()
    {
        ImageUI.fillAmount = 0;
    }

    /// <summary>
    /// �W�[�i��
    /// </summary>
    public void ProgressIncrease()
    {
        indicatorTimer += Time.deltaTime;
        if (indicatorTimer >= maxIndicatorTimer)
        {
            indicatorTimer = maxIndicatorTimer;
            onProgressComplete?.Invoke(this);
        }
        ImageUI.fillAmount = indicatorTimer / maxIndicatorTimer;
    }
    /// <summary>
    /// ��ֶi��
    /// </summary>
    public void ProgressDecrease()
    {
        indicatorTimer -= Time.deltaTime;
        if (indicatorTimer <= 0)
        {
            indicatorTimer = 0;
            onProgressToStart?.Invoke(this);
        }
        ImageUI.fillAmount = indicatorTimer/maxIndicatorTimer;
    }

    /// <summary>
    /// ���s�k�s
    /// </summary>
    public void ResetTimer()
    {
        indicatorTimer = 0;
        ImageUI.fillAmount = 0;
    }

    /// <summary>
    /// �ثe�i��
    /// </summary>
    public string CurrentProgress
    {
        get
        {
            return (ImageUI.fillAmount*100).ToString("0");
        }
    }
    public void Reset()
    {
        ImageUI = GetComponent<Image>();
        ImageUI.fillAmount = 1;
    }
}
