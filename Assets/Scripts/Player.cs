using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject explosionSE;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void explosion()
    {
        createExplosion();
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerFire>().enabled = false;
        Destroy(gameObject, .3f);
    }

    private void createExplosion()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        explosion.transform.localScale = transform.localScale * 2.5f;
        Destroy(explosion, 1f);

        GameObject explosionSEObject = Instantiate(explosionSE, transform.position, Quaternion.identity);
        Destroy(explosionSEObject, 3f);
    }
}
