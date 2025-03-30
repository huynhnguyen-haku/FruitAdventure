using Unity.VisualScripting;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    #region Variables
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Collider2D cl2d;
    #endregion

    #region GameObject Variables
    public GameObject BoxCollider;
    public GameObject brokenparts;
    public GameObject fruit;
    #endregion

    private float jumpForce = 6f;
    public int life = 1;
    AudioManager audioManager;


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
            audioManager.PlaySFX(audioManager.box);
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpForce;
            CheckBoxLives();
        }
    }


    private void CheckBoxLives()
    {
        life--;
        animator.Play("Hit");
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
    private void DestroyBox()
    {
        Destroy(transform.parent.gameObject);
    }
}
