using System.Collections;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    public Animator animator;

    public float distanceRaycast = 10f;

    private float coldownAttack = 1.5f;
    private float actualCooldowAttack;

    public GameObject beeBullet;

    private void Start()
    {
        actualCooldowAttack = 0;
    }

    void Update()
    {
        if (actualCooldowAttack > 0)
        {
            actualCooldowAttack -= Time.deltaTime;
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanceRaycast);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                animator.Play("Attack");
                StartCoroutine(SpawnBulletAfterDelay(0.15f));
                actualCooldowAttack = coldownAttack;
            }
        }
    }

    private IEnumerator SpawnBulletAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(beeBullet, transform.position, Quaternion.identity);
    }
}
