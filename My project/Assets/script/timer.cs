using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject gameOverPanel;
    public GameObject GagnerPanel;

    private float timeRemaining = 60f;
    private bool isTimerRunning = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        GagnerPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && !isTimerRunning)
        {
            isTimerRunning = true;
        }

        if (isTimerRunning && timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if (timeRemaining <= 0f)
        {
            isTimerRunning = false;
            timerText.text = "00:00";
            ShowGameOver();
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gameOverPanel.activeSelf)
        {
            ResetGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GagnerPanel.activeSelf)
        {
            ResetGame();
        }
    }

    void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowWin()
    {
        GagnerPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        isTimerRunning = false;
        timeRemaining = 60f;
        timerText.text = string.Format("{0:00}:{1:00}", 1, 0);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        GagnerPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowWin();
        }
    }
}
