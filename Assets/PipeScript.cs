using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour{
    public double moveSpeed;
    public float deadZone = -10;
    public LogicScript logic;

    void Start(){
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        moveSpeed = logic.moveSpeed;
    }

    void Update(){
        if(logic.birdIsAlive){
            transform.position += (Vector3.left * (float)moveSpeed) * Time.deltaTime;
        }
        if(transform.position.x < deadZone){
            Destroy(gameObject);
        }    
    }

}
