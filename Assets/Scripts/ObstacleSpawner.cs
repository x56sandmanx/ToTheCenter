using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnTime;
    [SerializeField] private Transform playerTransform;
    public float timer;
    public float speed;
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
            float randX = Random.Range(playerTransform.position.x - 5, playerTransform.position.x + 5);
            if(randX < -10)
            {
                randX = playerTransform.position.x + 5;
            }
            if(randX > 10)
            {
                randX = playerTransform.position.x - 5;
            }
            Vector3 randomPos = new Vector3(randX,transform.position.y,0);
            Instantiate(obstaclePrefab, randomPos, transform.rotation);
            if(GameData.level == "Level 1" && obstaclePrefab.gameObject.tag == "Obstacle")
                obstaclePrefab.GetComponent<ObstacleMovement>().speed = 2.0f;
            if (GameData.level == "Level 2" && obstaclePrefab.gameObject.tag == "Obstacle")
                obstaclePrefab.GetComponent<ObstacleMovement>().speed = 2.25f;
            if (GameData.level == "Level 3" && obstaclePrefab.gameObject.tag == "Obstacle")
                obstaclePrefab.GetComponent<ObstacleMovement>().speed = 2.5f;
            if (GameData.level == "Level 4" && obstaclePrefab.gameObject.tag == "Obstacle")
                obstaclePrefab.GetComponent<ObstacleMovement>().speed = 3.0f;
            if (GameData.level == "Level 1" && obstaclePrefab.gameObject.tag == "Rock")
                obstaclePrefab.GetComponent<ObstacleMovement>().speed = 4.0f;
            if (GameData.level == "Level 1" && obstaclePrefab.gameObject.tag == "Rock")
                obstaclePrefab.GetComponent<ObstacleMovement>().speed = 4.5f;
            if (GameData.level == "Level 1" && obstaclePrefab.gameObject.tag == "Rock")
                obstaclePrefab.GetComponent<ObstacleMovement>().speed = 5.0f;
            if (GameData.level == "Level 1" && obstaclePrefab.gameObject.tag == "Rock")
                obstaclePrefab.GetComponent<ObstacleMovement>().speed = 5.5f;
            timer = 0;
        }
    }
}
