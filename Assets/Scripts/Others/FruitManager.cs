using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public TextMeshProUGUI fruitsCollected;
    private int fruitsCollectedCount;


    private void Start()
    {
        fruitsCollectedCount = PlayerPrefs.GetInt("FruitsCollected", 0);
        UpdateFruitsCollectedText();
    }


    public void CollectFruit()
    {
        fruitsCollectedCount++;
        PlayerPrefs.SetInt("FruitsCollected", fruitsCollectedCount);
        PlayerPrefs.Save();
        UpdateFruitsCollectedText();
    }
    private void UpdateFruitsCollectedText()
    {
        fruitsCollected.text = fruitsCollectedCount.ToString();
    }
    public void ResetFruits()
    {
        PlayerPrefs.SetInt("FruitsCollected", 0);
        PlayerPrefs.Save();
    }
}
