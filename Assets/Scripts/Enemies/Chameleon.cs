using System.Collections;
using UnityEngine;

public class Chameleon : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float speed = 2f;
    private float waitTime;
    public float startWaitTime = 2;

    public Transform[] moveSpots;
    private int i = 0;
    private Vector2 actualPosition;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float cooldownAttack = 1.5f;
    private float actualCooldownAttack;

    public GameObject damageZone;

    private bool isAttacking = false; // New variable to track attack state

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        waitTime = startWaitTime;
        actualCooldownAttack = 0;
        damageZone.SetActive(false);
    }

    private void Update()
    {
        if (!isAttacking) // Only move if not attacking
        {
            MoveBetweenSpots();
        }
        HandleAttack();
    }

    void MoveBetweenSpots()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                i = (i + 1) % moveSpots.Length;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemyMoving()
    {
        actualPosition = transform.position;
        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > actualPosition.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Đúng hướng (tiến về phía trước)
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x < actualPosition.x)
        {
            transform.localScale = new Vector3(1, 1, 1); // Đúng hướng (tiến về phía trước)
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x == actualPosition.x)
        {
            animator.SetBool("Idle", true);
        }
    }


    private void HandleAttack()
    {
        if (actualCooldownAttack > 0)
        {
            actualCooldownAttack -= Time.deltaTime;
        }
        else
        {
            Vector2 direction = transform.localScale.x > 0 ? Vector2.left : Vector2.right; // Adjusted direction
            RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, direction, attackRange);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                animator.Play("Attack");
                StartCoroutine(EnableDamageZone(0.25f));
                actualCooldownAttack = cooldownAttack;
            }
        }
    }

    private IEnumerator EnableDamageZone(float delay)
    {
        isAttacking = true; // Set attacking state to true
        yield return new WaitForSeconds(delay);
        damageZone.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageZone.SetActive(false);
        isAttacking = false; // Set attacking state to false
    }
}
