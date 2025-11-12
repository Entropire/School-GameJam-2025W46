using UnityEngine;
using UnityEngine.Events;


public class TimeUI : MonoBehaviour
{
    [SerializeField]private TMPro.TextMeshProUGUI timeText;
     //Start is called once before the first execution of Update after the MonoBehaviour is created

    void UpdateTimeUI(float timeRemaining)
    {
        Debug.Log("Updating Time UI: " + timeRemaining);
        timeText.text = Mathf.FloorToInt(timeRemaining).ToString();
        
    }

    public void HandleTimerUpdate(float timeRemaining)
    {
        UpdateTimeUI(timeRemaining);
    }

}
