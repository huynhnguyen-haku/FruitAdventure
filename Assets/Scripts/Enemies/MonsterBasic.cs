using System.Collections;
using UnityEngine;

public class AllBasic : MonoBehaviour
{
    private Animator animator;

    private SpriteRenderer spriteRenderer;

    public float speed = 2f;

    private float waitTime;

    public float startWaitTime = 2;

    public Transform[] moveSpots;

    private int i = 0;

    private Vector2 actualPosition;

    private void Start()
    {
        waitTime = startWaitTime;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
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
            spriteRenderer.flipX = true;
            animator.SetBool("Idle", false);

        }
        else if (transform.position.x < actualPosition.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x == actualPosition.x)
        {
            animator.SetBool("Idle", true);
        }
    }
}
