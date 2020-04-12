using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class EnemyBullet : MonoBehaviour
{
    private float bulletSpeed;
    private Rigidbody2D rb;
    private Transform firePosition;

    // Start is called before the first frame update
    void Start()
    {

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
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<Player>().explosion();
        }
    }

    public void fireAtDirection(Transform t)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 fireToPlayer = t.position - firePosition.position;
        float fireAngle = Mathf.Atan2(fireToPlayer.y, fireToPlayer.x) * Mathf.Rad2Deg;
        rb.rotation = fireAngle;
        rb.AddRelativeForce(new Vector2(1f, 0f) * bulletSpeed, ForceMode2D.Impulse);
    }

    public void fireAtDirection(float angle)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.rotation = angle;
        rb.AddRelativeForce(new Vector2(1f, 0f) * bulletSpeed, ForceMode2D.Impulse);
    }

    public void setFirePosition(Transform t)
    {
        firePosition = t;
    }

    public void setBulletSpeed(float speed)
    {
        bulletSpeed = speed;
    }
}
