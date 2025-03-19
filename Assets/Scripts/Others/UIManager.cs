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
        Time.timeScale = 0;
        optionPanel.SetActive(true);
    }

    public void Continue()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        Time.timeScale = 1;
        optionPanel.SetActive(false);
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
        SceneManager.LoadScene("Main Menu");
    }
}
