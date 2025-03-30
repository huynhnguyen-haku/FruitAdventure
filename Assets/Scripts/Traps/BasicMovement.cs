using System.Collections;
using UnityEngine;

public class BasicMovement : MonoBehaviour
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
        MoveTowardsTarget();
        if (IsTargetReached())
        {
            HandleWaiting();
        }
    }


    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);
    }
    private bool IsTargetReached()
    {
        return Vector2.Distance(transform.position, moveSpots[i].position) < 0.1f;
    }
    private void HandleWaiting()
    {
        if (waitTime <= 0)
        {
            UpdateTargetIndex();
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
    private void UpdateTargetIndex()
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
    }
}
