using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject explosionSE;
    public Animator animator;

    private float invincibleTime;

    // Start is called before the first frame update
    void Start()
    {
        invincibleTime = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        invincibleTime -= Time.deltaTime;
        if (isInvincible())
        {
            animator.SetBool("isInvincible", true);
        }
        else
        {
            animator.SetBool("isInvincible", false);
        }
    }

    public void explosion()
    {
        createExplosion();
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerFire>().enabled = false;
        GameObject.Find("GameManager").GetComponent<GameManager>().playerReturnAfterSeconds(1);
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

    public bool isInvincible()
    {
        if (invincibleTime <= 0)
            return false;
        else
            return true;
    }
}
