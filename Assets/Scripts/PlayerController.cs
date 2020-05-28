using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    private static PlayerController instance;

    private static PlayerController Instance { get { return instance; } }

    private float x;

    public float X { get { return x; } }

    private PlayerMotor motor;

    private PlayerController myPlayer;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);

        } else {
            instance = this;
        }
    }

    void Start () {
        motor = GetComponent<PlayerMotor>();
        myPlayer = GetComponent<PlayerController>();
	}
	

	void Update () {


        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        if(rotationZ < -90 || rotationZ > 90) {
            GetComponent<SpriteRenderer>().flipX = true;


        }else if (rotationZ > -90 || rotationZ < 90) {
            GetComponent<SpriteRenderer>().flipX = false;
        }


//Récupère la valeur des axes
x = Input.GetAxisRaw("Horizontal");
        
        /*if(mousePosition == -1) {
            GetComponent<SpriteRenderer>().flipX = true;

        } else if(x == 1) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        */

        float _y = Input.GetAxisRaw("Jump");

        //Récupère velocity
        Vector2 _velocity = new Vector2(x, _y);

        // Applique velocity dans player motor
        motor.RunAndJump(_velocity);
    }
      
}
