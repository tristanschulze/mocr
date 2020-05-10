using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    
    public CharacterController mcc;
    public Animator my_animator;
    
    public float movement_speed = 1f;
    public float rotation_speed = 5f;

    // Update is called once per frame
    void Update()
    {
        

       // Debug.Log(transform.forward);

        Vector3 cmove = transform.forward * touch_controller.movement.y * Time.deltaTime;
        Vector3 crot = transform.up * touch_controller.movement.x * Time.deltaTime;


        //Debug.Log(cmove.magnitude);

        my_animator.SetFloat("walkspeed", touch_controller.movement.magnitude );

         if( cmove.magnitude!=0){
             my_animator.speed = touch_controller.movement.magnitude*2f;
         }else{

             my_animator.speed = 1f;
         }

    

        if(!mcc.isGrounded){

            cmove += Physics.gravity * .5f;
        }


        mcc.Move(cmove * movement_speed);
        this.transform.Rotate( crot * rotation_speed );




    }
}
