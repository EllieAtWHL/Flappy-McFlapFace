using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour{
    public double moveSpeed;
    public double bottomSpeedAdjuster = 0.5;
    public double topSpeedAdjuster = 0.8;
    public float deadZone = -10;
    public double bottomScale = 0.5;
    public double topScale = 1;
    public LogicScript logic;

    void Start(){
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        moveSpeed = logic.moveSpeed * Random.Range((float)bottomSpeedAdjuster, (float)topSpeedAdjuster);
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z + (float)moveSpeed
        );
        float randomScale = Random.Range((float)bottomScale, (float)topScale);
        transform.localScale = new Vector3(randomScale, randomScale, transform.localScale.z);
    }

    void Update(){
        transform.position += (Vector3.left * (float)moveSpeed) * Time.deltaTime;

        if(transform.position.x < deadZone){
            Destroy(gameObject);
        }
    }
}
