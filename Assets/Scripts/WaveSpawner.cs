using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject bomberGreenPrefab;
    public GameObject bomberRedPrefab;
    public GameObject scoutPrefab;

    public Transform[] spawnPoints;

    private int wave;

    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time + Time.deltaTime > 5 && wave == 0)
        {
            wave++;
            spawnBombers(spawnPoints[0], 4, -transform.up, false);
        }
        if(Time.time + Time.deltaTime > 10 && wave == 1)
        {
            wave++;
            spawnBombers(spawnPoints[2], 4, - transform.up, false);
        }
        if (Time.time + Time.deltaTime > 15 && wave == 2)
        {
            wave++;
            spawnBombers(spawnPoints[6], 5, transform.right, true);
        }
        if (Time.time + Time.deltaTime > 18 && wave == 3)
        {
            wave++;
            spawnScout(spawnPoints[1], spawnPoints[4]);
        }
        if (Time.time + Time.deltaTime > 22 && wave == 4)
        {
            wave++;
            spawnBombers(spawnPoints[0], 4, - transform.up, false);
        }
        if (Time.time + Time.deltaTime > 26 && wave == 5)
        {
            wave++;
            spawnBombers(spawnPoints[2], 4, - transform.up, false);
        }
        if (Time.time + Time.deltaTime > 35 && wave == 6)
        {
            wave++;
            spawnScout(spawnPoints[6], spawnPoints[3]);
            spawnScout(spawnPoints[7], spawnPoints[5]);
        }
        if (Time.time + Time.deltaTime > 45 && wave == 7)
        {
            wave++;
            spawnScout(spawnPoints[1], spawnPoints[4]);
            spawnBombers(spawnPoints[6], 5, new Vector2(1f, -1f), false);
            spawnBombers(spawnPoints[7], 5, new Vector2(-1f, -1f), false);
        }
    }

    public void spawnBombers(Transform spawnPoint, int count, Vector2 dir, bool spawnRed)
    {
        StartCoroutine(spawnBombersCoroutine(spawnPoint, count, dir, spawnRed));
    }

    private IEnumerator spawnBombersCoroutine(Transform spawnPoint, int count, Vector2 dir, bool spawnRed)
    {
        for (int i = 0; i < count; i++)
        {
            var bomberPrefab = bomberGreenPrefab;
            if (i == count - 1 && spawnRed)
                bomberPrefab = bomberRedPrefab;
            GameObject bomber = Instantiate(bomberPrefab, spawnPoint.position, bomberPrefab.transform.rotation);
            bomber.GetComponent<Rigidbody2D>().rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            bomber.GetComponent<Rigidbody2D>().AddForce(dir * 2f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(.5f);
        }
        //yield break;
    }

    public void spawnScout(Transform spawnPoint, Transform moveTo)
    {
        GameObject scout = Instantiate(scoutPrefab, spawnPoint.position, scoutPrefab.transform.rotation);
        scout.GetComponent<EnemyScout>().setMovePoint(moveTo);
    }
}
