using Unity.VisualScripting;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Collider2D cl2d;

    public GameObject BoxCollider;

    public GameObject brokenparts;

    public GameObject fruit;

    private float jumpForce = 6f;

    AudioManager audioManager;

    public int life = 1;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cl2d = GetComponent<Collider2D>();
        fruit.SetActive(false);
        fruit.transform.SetParent(FindObjectOfType<FruitManager>().transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpForce;
            life--;
            animator.Play("Hit");
            audioManager.PlaySFX(audioManager.box);
            if (life <= 0)
            {
                fruit.SetActive(true);
                cl2d.enabled = false;
                BoxCollider.SetActive(false);
                spriteRenderer.enabled = false;
                brokenparts.SetActive(true);
                Invoke("DestroyBox", 0.5f);
            }
        }
    }

    private void DestroyBox()
    {
        Destroy(transform.parent.gameObject);
    }
}
