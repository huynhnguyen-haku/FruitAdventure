using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.checkPoint);
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);
            
            AnimateFlag();
        }
    }


    private void AnimateFlag()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
