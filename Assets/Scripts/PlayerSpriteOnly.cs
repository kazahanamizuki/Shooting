using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteOnly : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.up * 2f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {        
        if(transform.position.y > -4f)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }
}
