using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        ClearStageData();
        StartCoroutine(LoadLevel());
    }

    private static void ClearStageData()
    {
        PlayerPrefs.DeleteKey("CheckPointPositionX");
        PlayerPrefs.DeleteKey("CheckPointPositionY");
        PlayerPrefs.SetInt("FruitsCollected", 0);
        PlayerPrefs.SetInt("RespawnCount", 0);
    }

    IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("start");
    }
}
