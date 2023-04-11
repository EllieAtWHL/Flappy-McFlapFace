using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnScript : MonoBehaviour{
    public GameObject cloud;
    public float baseSpawnRate = 3;
    public float heightOffset = 10;
    private float timer = 0;
    public LogicScript logic;

    void Start(){
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnCloud(0);
    }

    void Update(){
        float lowRange = baseSpawnRate * (7/10);
            
        if (timer < Random.Range(lowRange, baseSpawnRate)){
            timer += Time.deltaTime;
        }else{
            spawnCloud(10);
            timer = 0;
        }     
    }

    void spawnCloud(float xPosition){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(cloud, new Vector3(xPosition, Random.Range(lowestPoint, highestPoint), 2), transform.rotation);
    }
}
