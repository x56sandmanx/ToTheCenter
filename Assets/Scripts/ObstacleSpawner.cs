using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnTime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            float randX = Random.Range(-10, 10);
            Vector3 randomPos = new Vector3(randX,transform.position.y,0);
            Instantiate(obstaclePrefab, randomPos, transform.rotation);
            timer = 0;
        }
    }
}