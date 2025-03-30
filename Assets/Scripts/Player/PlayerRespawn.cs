using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private Animator animator;
    private int life;
    private AudioManager audioManager;
    private int respawnCount;

    public GameObject[] hearts;

    private Vector2 initialSpawnPoint;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
        respawnCount = PlayerPrefs.GetInt("RespawnCount", 0);
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        life = hearts.Length;
        initialSpawnPoint = transform.position;

        HandleSpawnLocation();

        animator.Play("Appear");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CriticalDmgZone"))
        {
            PlayerCriticalDamaged();
        }
        else if (collision.gameObject.CompareTag("DamageZone"))
        {
            PlayerDamaged();
        }
    }


    private void CheckLife()
    {
        if (life < 1)
        {
            hearts[0].SetActive(false);
            animator.Play("Hit");
            GetComponent<PlayerMovement>().enabled = false;
            StartCoroutine(RespawnPlayerAfterDelay(0.25f));
        }
        else if (life < 2)
        {
            hearts[1].SetActive(false);
            animator.Play("Hit");
        }
        else if (life < 3)
        {
            hearts[2].SetActive(false);
            animator.Play("Hit");
        }
    }
    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("CheckPointPositionX", x);
        PlayerPrefs.SetFloat("CheckPointPositionY", y);
    }
    private void HandleSpawnLocation()
    {
        if (PlayerPrefs.HasKey("CheckPointPositionX") && PlayerPrefs.HasKey("CheckPointPositionY"))
        {
            transform.position = new Vector2(
                PlayerPrefs.GetFloat("CheckPointPositionX"),
                PlayerPrefs.GetFloat("CheckPointPositionY")
            );
        }
        else
        {
            transform.position = initialSpawnPoint;
        }
    }
    private IEnumerator RespawnPlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        respawnCount++;
        PlayerPrefs.SetInt("RespawnCount", respawnCount);
        PlayerPrefs.Save();
        Debug.Log("Respawn Count: " + respawnCount);

        if (PlayerPrefs.HasKey("CheckPointPositionX") && PlayerPrefs.HasKey("CheckPointPositionY"))
        {
            transform.position = new Vector2(
                PlayerPrefs.GetFloat("CheckPointPositionX"),
                PlayerPrefs.GetFloat("CheckPointPositionY")
            );
        }
        else
        {
            transform.position = initialSpawnPoint;
        }

        animator.Play("Appear");
        GetComponent<PlayerMovement>().enabled = true;

        life = hearts.Length;
        foreach (var heart in hearts)
        {
            heart.SetActive(true);
        }
    }


    public void PlayerDamaged()
    {
        audioManager.PlaySFX(audioManager.playerHit);
        life--;
        CheckLife();
    }
    public void PlayerCriticalDamaged()
    {
        life = 0;
        foreach (var heart in hearts)
        {
            heart.SetActive(false);
        }
        animator.Play("Hit");
        audioManager.PlaySFX(audioManager.playerHit);
        GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(RespawnPlayerAfterDelay(0.25f));
    }
}

