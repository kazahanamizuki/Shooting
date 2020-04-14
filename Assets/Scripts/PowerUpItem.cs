using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    private string itemName;
    private bool isTriggered;
    // Start is called before the first frame update
    void Start()
    {
        itemName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {        
        if(collider.tag == "Player")
        {
            Physics2D.IgnoreCollision(collider,GetComponent<BoxCollider2D>());
            if (itemName.Contains("PowerUpWay"))
            {
                collider.gameObject.GetComponent<PlayerFire>().subFirePointEnable();
            }
            if(itemName.Contains("PowerUpDamage"))
            {
                collider.gameObject.GetComponent<PlayerFire>().fireDamagePowerUp();
            }
            Destroy(gameObject);
        }
        
    }
}
