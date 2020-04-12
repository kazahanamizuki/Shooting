using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePointL;
    public Transform firePointR;
    public AudioSource fireSE;

    public float fireRate;
    private float nextFireTime;
    private float nextFrameTime;

    // Start is called before the first frame update
    void Start()
    {
        nextFireTime = Time.time;
        nextFrameTime = Time.time;
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
            fireSE.Play();
        }
    }
}