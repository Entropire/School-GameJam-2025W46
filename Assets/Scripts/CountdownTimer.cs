using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> onTimeChanged;
    [SerializeField] private UnityEvent onTimerDone;
    [SerializeField] private float timeInSeconds = 300f;
    [SerializeField] private float updateInterval = 0.5f;

    private float timeRemaining;
    private bool isRunning = true;
    private float timeSinceLastUpdate;

    private void Start()
    {
        timeRemaining = timeInSeconds;
        onTimeChanged?.Invoke(timeRemaining);
    }

    private void Update()
    {
        if (!isRunning) return;

        timeRemaining -= Time.deltaTime;
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= updateInterval)
        {
            onTimeChanged?.Invoke(timeRemaining);
            timeSinceLastUpdate = 0f;
        }

        if (timeRemaining <= 0f)
        {
            isRunning = false;
            onTimeChanged?.Invoke(0);
            onTimerDone?.Invoke();
        }
    }
}
