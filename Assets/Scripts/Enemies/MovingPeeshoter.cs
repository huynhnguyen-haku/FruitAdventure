using System.Collections;
using UnityEngine;

public class MovingPeeshoter : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float speed = 2f;
    private float waitTime;
    public float startWaitTime = 2;

    public Transform[] moveSpots;
    private int i = 0;
    private Vector2 actualPosition;

    public GameObject bulletPrefab;
    public Transform[] launchSpawnPoints;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float cooldownAttack = 1.5f;
    private float actualCooldownAttack;

    private bool isAttacking = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        waitTime = startWaitTime;
        actualCooldownAttack = 0;
    }

    private void Update()
    {
        if (!isAttacking)
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
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x < actualPosition.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
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
            Vector2 direction = transform.localScale.x > 0 ? Vector2.left : Vector2.right;
            Debug.DrawRay(attackPoint.position, direction * attackRange, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, direction, attackRange);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                {
                    animator.Play("Attack");
                    StartCoroutine(EnableAttack());
                    actualCooldownAttack = cooldownAttack;
                }
            }
        }
    }

    private IEnumerator EnableAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.25f);
        bool isFacingLeft = transform.localScale.x > 0;
        foreach (var spawnPoint in launchSpawnPoints)
        {
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            Bullet bulletScript = newBullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.left = isFacingLeft;
            }
        }
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }

}
