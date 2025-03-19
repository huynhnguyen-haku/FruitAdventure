using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFinish : MonoBehaviour
{
    private Animator animator;
    public MonoBehaviour movementScript; 

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("FinishLine"))
        {
            Debug.Log("Level Completed");
            animator.Play("Disappear");
            movementScript.enabled = false;
        }
    }
}
