using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Temp_GameManager : MonoBehaviour
{
    public static Temp_GameManager Instance { get; private set; }
    public string sNextScene;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public int currentDay;
    public int totalRevenue;
    public int dailyRevenue;
    public float closingTime = 240f;
    public float remainingTime;

    private bool isGameRunning = true;

    void Start() {
        remainingTime = closingTime;

        if (Temp_UIManager.Instance != null) {
            Temp_UIManager.Instance.UpdateDay(currentDay);
            Temp_UIManager.Instance.UpdateDailyRevenue(dailyRevenue);
            Temp_UIManager.Instance.UpdateTimeBar(remainingTime / closingTime);
        }
    }

    
    void Update() {
        if (isGameRunning) {
            if (remainingTime <= 0)
                Close();

            remainingTime -= Time.deltaTime;
            Temp_UIManager.Instance.UpdateTimeBar(remainingTime / closingTime);
        }
    }

    public void AddRevenue(int amount) {
        dailyRevenue += amount;
        totalRevenue += amount;
        Temp_UIManager.Instance.UpdateDailyRevenue(dailyRevenue);
    }
    public void PauseGame() {
        isGameRunning = false;
        Time.timeScale = 0;
    }
    public void ResumeGame() {
        isGameRunning = true;
        Time.timeScale = 1;
    }

    private void Open() {
        isGameRunning = true;
        Debug.Log("Open!!!!!!!!!!!!!!!!!!!!!");
    }

    private void Close() {
        isGameRunning = false;
        Debug.Log("Closedddddddddddddddddddd");
    }

}
