using UnityEngine;

public class Peeshoter : MonoBehaviour
{
    private float waitedTime;

    public float waitTimeToAttack = 3;

    public Animator animator;

    public GameObject bulletPrefab;

    public Transform launchSpawnPoint;

    private void Start()
    {
        waitedTime = waitTimeToAttack;
    }

    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimeToAttack;
            animator.Play("Attack");
            Invoke("LaunchBullet", 0.2f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    private void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
