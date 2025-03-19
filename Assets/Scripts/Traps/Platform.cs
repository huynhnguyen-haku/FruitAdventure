using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;

    public float startWaitTime;

    private float waitTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp("s") || Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = startWaitTime;
        }

        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
           if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = startWaitTime;
            }
            else 
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey("space"))
        {
            effector.rotationalOffset = 0f;
        }
    }
}
