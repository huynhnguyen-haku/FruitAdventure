using System.Collections;
using UnityEngine;

public class Bee : MonoBehaviour
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
}
