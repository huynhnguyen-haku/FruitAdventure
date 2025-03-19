using UnityEngine;

public class FruitCollected : MonoBehaviour
{
    private Animator animator;
    private Collider2D fruitCollider;
    private bool isCollected = false;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        fruitCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollected)
        {
            isCollected = true; 
            audioManager.PlaySFX(audioManager.fruit);
            animator.Play("CollectAnimation");

            if (fruitCollider != null)
            {
                fruitCollider.enabled = false;
            }

            FruitManager fruitManager = FindAnyObjectByType<FruitManager>();
            if (fruitManager != null)
            {
                fruitManager.CollectFruit();
            }

            float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(gameObject, animationLength);
        }
    }
}
