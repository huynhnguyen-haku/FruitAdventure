using UnityEngine;


public class Trampoline : MonoBehaviour
{
    private Animator animator;

    public float jumpForce = 14f;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.trampoline);
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpForce;
            animator.Play("Jump");
        }
    }
}
