using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiiangSpawner : MonoBehaviour
{
    public GameObject tiang;
    public float spawnTime;
    public float yPosMin, yPosMax;

    IEnumerator SpawnTiangCoroutine()
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(tiang, transform.position + Vector3.up * Random.Range(yPosMin, yPosMax), Quaternion.identity);
        StartCoroutine(SpawnTiangCoroutine());
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTiangCoroutine());
    }


}
