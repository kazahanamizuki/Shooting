using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerSpriteOnly;
    public Transform playerSpawnPoint;

    private float spawnTime;
    private bool spawning;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 0;
        spawning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime <= 0)
        {
            if (spawning)
            {
                playerReturn();
                spawning = false;
            }   
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }

    private void playerReturn()
    {
        GameObject playerSO = Instantiate(playerSpriteOnly, playerSpawnPoint.position, Quaternion.identity);
    }

    public void playerReturnAfterSeconds(float s)
    {
        spawnTime = s;
        spawning = true;
    }
}
