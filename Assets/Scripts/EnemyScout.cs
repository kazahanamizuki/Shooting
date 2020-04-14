using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScout : MonoBehaviour
{
    public float shootTimer;
    public float shootRateFast = .05f;
    public float shootTimesFast = 5;
    public float shootTimesRemain;
    public float shootRateSlow = 2f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 3f;
    public Transform[] firePositions;

    public AudioSource fireSE;

    public GameObject itemDrop;

    private Transform movePoint;
    private float moveSpeed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Enemy>().setMaxHP(1200);
        shootTimesRemain = shootTimesFast;
        shootTimer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Enemy>().isAlive)
        {
            move();
            shoot();
        }        
    }

    private void shoot()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        else
        {
            foreach (var firePosition in firePositions)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
                    var enemyBullet = bullet.GetComponent<EnemyBullet>();
                    enemyBullet.setBulletSpeed(bulletSpeed);
                    enemyBullet.setFirePosition(firePosition);
                    enemyBullet.fireAtDirection(-105 + i * 15);
                }

                fireSE.Play();

                if (shootTimesRemain > 0)
                {
                    shootTimesRemain -= 1;
                    shootTimer += shootRateFast;
                }
                else
                {
                    shootTimesRemain = shootTimesFast;
                    shootTimer += shootRateSlow;
                }
            }
        }
    }

    private void move()
    {
        var root = movePoint.position - transform.position;
        if(root.magnitude < 0.05)
        {
            transform.position = movePoint.position;
        }
        else
        {
            transform.position = transform.position + root.normalized * moveSpeed * Time.deltaTime;
        }
    }

    public void setMovePoint(Transform t)
    {
        movePoint = t;
    }

    private void OnDestroy()
    {
        Instantiate(itemDrop, transform.position, Quaternion.identity);
    }
}
