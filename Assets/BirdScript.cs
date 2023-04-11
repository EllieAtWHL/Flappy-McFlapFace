using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour{
    public Rigidbody2D rigidBody;
    public float flapStrength = 5;
    public LogicScript logic;
    public float deadZone = -8;

    void Start(){
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update(){
        if (transform.position.y < deadZone){
            logic.gameOver();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && logic.birdIsAlive)
        {
            rigidBody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer != 7)
        {
            logic.gameOver();
        }
        
    }
}
