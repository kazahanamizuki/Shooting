using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomber : MonoBehaviour
{
    public float shootTimer;
    public float shootRate = 2f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public Transform firePosition;

    public AudioSource fireSE;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Enemy>().setMaxHP(2);
        shootTimer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Enemy>().isAlive)
        {
            shoot();
        }
    }

    void shoot()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
            var enemyBullet = bullet.GetComponent<EnemyBullet>();
            enemyBullet.setBulletSpeed(bulletSpeed);
            enemyBullet.setFirePosition(firePosition);
            if (GameObject.FindGameObjectWithTag("Player") != null)
                enemyBullet.fireAtDirection(GameObject.FindGameObjectWithTag("Player").transform);
            else
                enemyBullet.fireAtDirection(-90f);
            fireSE.Play();
            shootTimer += shootRate;
        }
    }
}
