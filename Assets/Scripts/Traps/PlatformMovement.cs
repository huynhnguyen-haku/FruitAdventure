using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 2f;
    public float startWaitTime = 2;
    public Transform[] moveSpots;

    private float waitTime;
    private int i = 0;
    private bool reverse = false;

    private void Start()
    {
        waitTime = startWaitTime;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (!reverse)
                {
                    if (i < moveSpots.Length - 1)
                    {
                        i++;
                    }
                    else
                    {
                        reverse = true;
                        i--;
                    }
                }
                else
                {
                    if (i > 0)
                    {
                        i--;
                    }
                    else
                    {
                        reverse = false;
                        i++;
                    }
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
