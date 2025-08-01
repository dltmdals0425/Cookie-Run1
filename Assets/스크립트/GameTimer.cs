using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;//TEXT MESH PRO »ç¿ë

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;
    [SerializeField] private TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private bool isRunning =false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        StartTimer();
    }

    private void Update()
    {
        if (!isRunning) return;
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timerText.text = $"{minutes}:{seconds:00}";
    }
    public void StartTimer()
    {
        isRunning = true;
        elapsedTime = 0f;

    }
    public void StopTimer()
    { isRunning = false; }

    public float GetElapsedTime()
    { return elapsedTime; }


}
