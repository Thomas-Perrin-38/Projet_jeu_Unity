using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateAnim {
    Idle,
    Run,
    Jump
}

public class AnimationController : MonoBehaviour {

    private Animator anim;
    private PlayerController player;
    private PlayerMotor playerMotor;
    private StateAnim state;



	void Start () {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        playerMotor = GetComponent<PlayerMotor>();
	}
	

	void Update () {
        bool run = player.X == 1 || player.X == -1;

        if(run && playerMotor.Grounded) {
            state = StateAnim.Run;
            Debug.Log("je cours");

        }else if(!run && playerMotor.Grounded){
            state = StateAnim.Idle;
            Debug.Log("je suis static");

        } else if(!playerMotor.Grounded) {
            state = StateAnim.Jump;
            Debug.Log("je saute");
        }
        Animation();
    }

    private void Animation() {
        switch(state) {
            case StateAnim.Idle:
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
                anim.SetBool("Ground", true);
                break;
            case StateAnim.Run:
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);
                anim.SetBool("Ground", true);
                break;
            case StateAnim.Jump:
                anim.SetBool("Ground", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Run", false);
                break;
        }
    }
}
