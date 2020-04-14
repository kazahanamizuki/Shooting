using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItemMovement : MonoBehaviour
{
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
}
