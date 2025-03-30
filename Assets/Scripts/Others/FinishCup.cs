using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCup : MonoBehaviour
{
    private Animator animator;
    private Collider2D cl2D;
    private float jumpForce = 12f;
    AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        cl2D = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.finishStage);
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpForce;
           
            AnimateCup();
            UnlockNewLevel();
            StartCoroutine(GoToNextLevelAfterDelay(1f));
        }
    }


    private void AnimateCup()
    {
        animator.Play("Hit");
        cl2D.enabled = false;
    }
    private void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
    private IEnumerator GoToNextLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneController.instance.NextLevel();
    }
}
