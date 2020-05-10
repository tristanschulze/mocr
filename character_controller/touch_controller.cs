using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_controller : MonoBehaviour
{
   

    public GameObject ring; // your 2d graphic element for joytick outside ring
    public GameObject dot; // your 2d graphic element for joytick stick 

    Vector2 anchor;
    Vector2 cpos; 

    bool touching = false;

    public static Vector2 movement; // touch movement vector shared!


    void Start(){

            ring.SetActive(false);
            dot.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {

            // mousedown - touchdown --------------------------------------------
            if(Input.GetMouseButtonDown(0)){

                     anchor = new Vector2(  Input.mousePosition.x,  Input.mousePosition.y);
                    //set touch anchor
                    ring.transform.position = anchor;
                    ring.SetActive(true);
                    dot.SetActive(true);
                     touching = true;

            }




            // mousemove - touchmove ---------------------------------------------
            if(Input.GetMouseButton(0)){

                    // update the offset between anchor point and current finger position
                    cpos = new Vector2(  Input.mousePosition.x,  Input.mousePosition.y);
                    dot.transform.position = cpos;

            }


            // mouseup --------------------------------------------
            if(Input.GetMouseButtonUp(0)){

                    ring.SetActive(false);
                    dot.SetActive(false);
                    touching = false;



            }

    }




    void FixedUpdate()
    {

        if(touching){

            // if user touches > calc movement vector
            Vector2 off = cpos - anchor;
            Vector2 dir = Vector2.ClampMagnitude(off*.005f,1f);
            movement = dir;


        }else{

            // if user does not touch > set all to zero
             movement = Vector2.zero;
        }


    }


}
