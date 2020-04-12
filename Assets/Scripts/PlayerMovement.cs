using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private float moveX;
    private float moveY;

    private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 4f;
        playerHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") && !Input.GetKey("right"))
        {
            moveX = -1f;
        }
        else if (!Input.GetKey("left") && Input.GetKey("right"))
        {
            moveX = 1f;
        }
        else
        {
            moveX = 0f;
        }

        if(Input.GetKey("up") && !Input.GetKey("down"))
        {
            moveY = 1f;
        }
        else if (!Input.GetKey("up") && Input.GetKey("down"))
        {
            moveY = -1f;
        }
        else
        {
            moveY = 0f;
        }
        transform.Translate(new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime);

        float moveTo_x = Mathf.Clamp(transform.position.x, -screenBounds.x + playerWidth, screenBounds.x - playerWidth);
        float moveTo_y = Mathf.Clamp(transform.position.y, -screenBounds.y + playerHeight, screenBounds.y - playerHeight);
        transform.position = new Vector2(moveTo_x, moveTo_y);
    }
}
