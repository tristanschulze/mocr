using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
        
        public CharacterController mcc;
        public Animator my_animator;
        public float movement_speed = 4f;
        public float rotation_speed = 88f;

    // Update is called once per frame
    void Update()
    {
        
       // ------------ transform joystick input into move vectors   ---------------
        Vector3 cmove = transform.forward * touch_controller.movement.y * Time.deltaTime;
        Vector3 crot = transform.up * touch_controller.movement.x * Time.deltaTime;

       
          // ------------ manipulate animator along movment   ---------------
        my_animator.SetFloat("walkspeed", touch_controller.movement.magnitude );

         if( cmove.magnitude!=0){
             my_animator.speed = touch_controller.movement.magnitude*1.5f;
         }else{

             my_animator.speed = 1f;
         }

    
        // ------------ Player is grounded   ---------------
        // if(!mcc.isGrounded){
        //}


        // ------------ Apply gravity   ---------------
            cmove += Physics.gravity * .4f;
      

        // ------------ Apply movement & rotation   ---------------
        mcc.Move(cmove * movement_speed);
        this.transform.Rotate( crot * rotation_speed );




    }
}
