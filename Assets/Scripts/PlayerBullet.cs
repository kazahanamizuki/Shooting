using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 1;
    private float bulletSpeed = 10f;
    public Rigidbody2D rb;
    public GameObject playerBulletExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y) > 6f || Mathf.Abs(transform.position.x) > 3.5f)
        {
            Destroy(gameObject);
        }
    }

     private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            GameObject explosion = Instantiate(playerBulletExplosionPrefab, collider.ClosestPoint(transform.position), transform.rotation);
            Destroy(explosion, 1f);
            Destroy(gameObject);
            collider.GetComponent<Enemy>().takeDamage(damage);
        }
    }
}
