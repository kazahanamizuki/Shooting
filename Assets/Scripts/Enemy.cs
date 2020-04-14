using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP;
    public GameObject explosionEffect;
    public GameObject explosionSE;

    private float spawnInvincibleTime;
    public bool isAlive;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private bool outOfBound;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        spawnInvincibleTime = 1.5f;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        objectHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnInvincibleTime -= Time.deltaTime;

        if(maxHP <= 0 && isAlive)
        {
            isAlive = false;
            explosion();
        }

        if(spawnInvincibleTime <= 0)
        {
            checkOutOfBound();
            if (outOfBound)
            {
                Destroy(gameObject);
            }
        }
        
    }

    public void setMaxHP(int hp)
    {
        maxHP = hp;
    }

    public void takeDamage(int damage)
    {
        maxHP -= damage;
    }

    private void checkOutOfBound()
    {
        if (Mathf.Abs(transform.position.x) > screenBounds.x + objectWidth || Mathf.Abs(transform.position.y) > screenBounds.y + objectHeight)
        {
            outOfBound = true;
        }
    }

    void explosion()
    {
        createExplosion();
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, .3f);
    }

    private void createExplosion()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        explosion.transform.localScale = transform.localScale * 1.5f;
        Destroy(explosion, 1f);

        GameObject explosionSEObject = Instantiate(explosionSE, transform.position, Quaternion.identity);
        Destroy(explosionSEObject, 3f);
    }
}
