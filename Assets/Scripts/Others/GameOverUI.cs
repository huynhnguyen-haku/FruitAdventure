using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI totalScore;
    [SerializeField] TextMeshProUGUI totalDeath;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }
    private void Start()
    {
        audioManager.PlaySFX(audioManager.resultScreen);
        audioManager.musicSource.Stop();
        DisplayTotalDeath();
        DisplayTotalScore();
    }

    public void Restart()
    {
        ClearStageData();
        ResumeGameTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LevelSelection()
    {
        ClearStageData();
        ResumeGameTime();
        SceneManager.LoadScene("LevelSelection");
    }
    public void MainMenu()
    {
        ClearStageData();
        ResumeGameTime();
        SceneManager.LoadScene("Main Menu");
    }


    private static void ResumeGameTime()
    {
        Time.timeScale = 1;
    }
    private static void ClearStageData()
    {
        PlayerPrefs.DeleteKey("CheckPointPositionX");
        PlayerPrefs.DeleteKey("CheckPointPositionY");
        PlayerPrefs.SetInt("FruitsCollected", 0);
        PlayerPrefs.SetInt("RespawnCount", 0);
    }


    private void DisplayTotalScore()
    {
        int totalFruitsCollected = PlayerPrefs.GetInt("FruitsCollected");
        totalScore.text = totalFruitsCollected.ToString();
    }
    private void DisplayTotalDeath()
    {
        int totalDeaths = PlayerPrefs.GetInt("RespawnCount");
        totalDeath.text = totalDeaths.ToString();
    }
}
