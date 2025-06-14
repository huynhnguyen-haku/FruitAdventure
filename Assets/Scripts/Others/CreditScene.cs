using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditScene : MonoBehaviour
{
    public RectTransform creditText; 
    public float scrollSpeed = 100f; 
    public string mainMenuScene = "Main Menu"; 

    private bool isScrolling = true;


    private void Update()
    {
        if (isScrolling)
        {
            creditText.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
        }

        if (Input.anyKeyDown)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            LoadMainMenu();
        }
    }
    private void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
