using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionPanel;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }


    public void OptionPanel()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        PauseGame();
        optionPanel.SetActive(true);
    }
    private static void PauseGame()
    {
        Time.timeScale = 0;
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


    public void Continue()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        ResumeGameTime();
        optionPanel.SetActive(false);
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
        SceneManager.LoadScene("Main Menu");
    }
}
