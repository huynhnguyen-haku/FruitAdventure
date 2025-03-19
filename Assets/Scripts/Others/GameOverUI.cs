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
        PlayerPrefs.DeleteKey("CheckPointPositionX");
        PlayerPrefs.DeleteKey("CheckPointPositionY");
        PlayerPrefs.SetInt("FruitsCollected", 0);
        PlayerPrefs.SetInt("RespawnCount", 0);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void DisplayTotalScore()
    {
        int totalFruitsCollected = PlayerPrefs.GetInt("FruitsCollected");
        totalScore.text = totalFruitsCollected.ToString();
    }

    public void DisplayTotalDeath()
    {
        int totalDeaths = PlayerPrefs.GetInt("RespawnCount");
        totalDeath.text = totalDeaths.ToString();
    }
}
