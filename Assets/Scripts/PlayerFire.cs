using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject[] bulletPrefabs;
    private GameObject bulletPrefab;
    private int powerUpDamage = 0;
    public Transform firePointL;
    public Transform firePointR;
    public Transform firePointLsub1;
    public Transform firePointLsub2;
    public Transform firePointRsub1;
    public Transform firePointRsub2;
    private bool powerUpWay;
    public AudioSource fireSE;

    public float fireRate;
    private float nextFireTime;
    private float nextFrameTime;

    // Start is called before the first frame update
    void Start()
    {
        nextFireTime = Time.time;
        nextFrameTime = Time.time;
        bulletPrefab = bulletPrefabs[0];
        powerUpWay = false;
    }

    // Update is called once per frame
    void Update()
    {
        nextFrameTime += Time.deltaTime;
        if (Input.GetButton("Fire1") && nextFrameTime > nextFireTime)
        {
            nextFireTime = nextFrameTime + fireRate;
            Instantiate(bulletPrefab, firePointL.position, firePointL.rotation);
            Instantiate(bulletPrefab, firePointR.position, firePointR.rotation);
            if (powerUpWay)
            {
                Instantiate(bulletPrefab, firePointLsub1.position, firePointLsub1.rotation);
                Instantiate(bulletPrefab, firePointRsub1.position, firePointRsub1.rotation);
                Instantiate(bulletPrefab, firePointLsub2.position, firePointLsub2.rotation);
                Instantiate(bulletPrefab, firePointRsub2.position, firePointRsub2.rotation);
            }            
            fireSE.Play();
        }
    }

    public void subFirePointEnable()
    {
        powerUpWay = true;
    }

    public void fireDamagePowerUp()
    {
        if(powerUpDamage < 2)
            powerUpDamage++;
        bulletPrefab = bulletPrefabs[powerUpDamage];
    }
}