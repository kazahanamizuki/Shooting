using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject bomberPrefab;
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
        if (Time.time + Time.deltaTime > 3 && wave == 0)
        {
            wave++;
            spawnBombers(spawnPoints[0], 4, -transform.up);
        }
        if(Time.time + Time.deltaTime > 7 && wave == 1)
        {
            wave++;
            spawnBombers(spawnPoints[2], 4, - transform.up);
        }
        if(Time.time + Time.deltaTime > 12 && wave == 2)
        {
            wave++;
            spawnScout(spawnPoints[1], spawnPoints[4]);
        }
        if (Time.time + Time.deltaTime > 14 && wave == 3)
        {
            wave++;
            spawnBombers(spawnPoints[0], 4, - transform.up);
        }
        if (Time.time + Time.deltaTime > 16 && wave == 4)
        {
            wave++;
            spawnBombers(spawnPoints[2], 4, - transform.up);
        }
        if (Time.time + Time.deltaTime > 20 && wave == 5)
        {
            wave++;
            spawnScout(spawnPoints[6], spawnPoints[3]);
            spawnScout(spawnPoints[7], spawnPoints[5]);
        }
        if (Time.time + Time.deltaTime > 30 && wave == 6)
        {
            wave++;
            spawnScout(spawnPoints[1], spawnPoints[4]);
            spawnBombers(spawnPoints[6], 5, new Vector2(1f, -1f));
            spawnBombers(spawnPoints[7], 5, new Vector2(-1f, -1f));
        }
    }

    public void spawnBombers(Transform spawnPoint, int count, Vector2 dir)
    {
        StartCoroutine(spawnBombersCoroutine(spawnPoint, count, dir));
    }

    private IEnumerator spawnBombersCoroutine(Transform spawnPoint, int count, Vector2 dir)
    {
        for (int i = 0; i < count; i++)
        {
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
