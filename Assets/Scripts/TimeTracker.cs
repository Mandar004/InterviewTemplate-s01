using UnityEngine;
using TMPro;
using System;

public class TimeTracker : MonoBehaviour
{
    public static TimeTracker Instance;

    public TMP_Text sceneTimeText;
    public TMP_Text sessionTimeText;
    public TMP_Text todayTimeText;
    public TMP_Text lifetimeTimeText;

    private float sceneTime;
    private float sessionTime;

    private DateTime sessionStartTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            sessionStartTime = DateTime.Now;
            sessionTime = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void start()
    {
        sessionTime = PlayerPrefs.GetFloat("SessionTime", 0f);
        sceneTime = 0f;
    }
    void Update()
    {
        sceneTime += Time.deltaTime;
        sessionTime += Time.deltaTime;


        PlayerPrefs.SetFloat("SessionTime", sessionTime);

        PlayerPrefs.SetFloat("TodayTime", PlayerPrefs.GetFloat("TodayTime", 0f) + Time.deltaTime);
        PlayerPrefs.SetFloat("LifetimeTime", PlayerPrefs.GetFloat("LifetimeTime", 0f) + Time.deltaTime);

        UpdateUIText();
    }

    void UpdateUIText()
    {
        sceneTimeText.text = "Scene Time: " + FormatTime(sceneTime);
        sessionTimeText.text = "Session Time: " + FormatTime(sessionTime);
        todayTimeText.text = "Today Time: " + FormatTime(PlayerPrefs.GetFloat("TodayTime"));
        lifetimeTimeText.text = "Lifetime Time: " + FormatTime(PlayerPrefs.GetFloat("LifetimeTime"));
    }

    string FormatTime(float totalSeconds)
    {
        int days = (int)(totalSeconds / 86400);
        int hours = (int)(totalSeconds / 3600) % 24;
        int minutes = (int)(totalSeconds / 60) % 60;
        int seconds = (int)(totalSeconds) % 60;

        if (days > 0)
            return $"{days}d {hours}h {minutes}m {seconds}s";
        else
            return $"{hours}h {minutes}m {seconds}s";
    }

    public void ResetSceneTimer()
    {
        sceneTime = 0f;
    }
}
