using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditScene : MonoBehaviour
{
    public RectTransform creditText; 
    public float scrollSpeed = 100f; 
    public string mainMenuScene = "Main Menu"; 

    private bool isScrolling = true;

    void Update()
    {
        if (isScrolling)
        {
            creditText.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
        }

        if (Input.anyKeyDown)
        {
            LoadMainMenu();
        }
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
