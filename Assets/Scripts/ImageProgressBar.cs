using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// ��n���Image��b�P�@��GameObject���U
/// ���~��Manager����ӳB�zUI����
/// </summary>
[RequireComponent(typeof(Image))]
public class ImageProgressBar : MonoBehaviour
{
    [Header("Radial Timers")]
    [SerializeField] private float indicatorTimer = 0f;
    [SerializeField] private float maxIndicatorTimer = 0.8f;
    [Header("UI Indicator")]
    [SerializeField] private Image ImageUI = null;

    public UnityAction<ImageProgressBar> onProgressComplete = null;
    public UnityAction<ImageProgressBar> onProgressToZero = null;

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
    /// <param name="isClickEvent">�O�_��Click����</param>
    public void ProgressIncrease(bool isClickEvent = false)
    {
        if (isClickEvent)
        {
            onProgressComplete?.Invoke(this);
            ImageUI.fillAmount = 1;
        }
        else
        {
            indicatorTimer += Time.deltaTime;
            if (indicatorTimer >= maxIndicatorTimer)
            {
                indicatorTimer = maxIndicatorTimer;
                onProgressComplete?.Invoke(this);
            }
            ImageUI.fillAmount = indicatorTimer / maxIndicatorTimer;
        }
    }
    /// <summary>
    /// ��ֶi��
    /// </summary>
    public void ProgressDecrease(bool isClickEvent = false)
    {
        if (isClickEvent)
        {
            onProgressToZero?.Invoke(this);
            ImageUI.fillAmount = 0;
        }
        else
        {
            indicatorTimer -= Time.deltaTime;
            if (indicatorTimer <= 0)
            {
                indicatorTimer = 0;
                onProgressToZero?.Invoke(this);
            }
            ImageUI.fillAmount = indicatorTimer/maxIndicatorTimer;
        }
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
