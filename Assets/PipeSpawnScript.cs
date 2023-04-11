using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour{
    public GameObject pipe;
    public float spawnRate = 2;
    public float heightOffset = 10;
    private float timer = 0;
    public LogicScript logic;

    void Start(){
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if(logic.birdIsAlive){
            spawnPipe();
        }        
    }

    void Update(){
        if(logic.birdIsAlive){
            if (timer < spawnRate){
                timer += Time.deltaTime;
            } else{
                spawnPipe();
                timer = 0;
            }
        }
    }
 
    void spawnPipe(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
 
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
