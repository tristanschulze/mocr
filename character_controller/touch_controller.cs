using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_controller : MonoBehaviour
{
   

    public GameObject ring;
    public GameObject dot;

    Vector2 anchor;
    Vector2 cpos;

    bool touching = false;

    public static Vector2 movement;

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

            // if user touches
            Vector2 off = cpos - anchor;
            Vector2 dir = Vector2.ClampMagnitude(off*.01f,1f);
            // x -1 / 1
            // y -1 / 1

            movement = dir;


        }else{

            // if user does not touch
             movement = Vector2.zero;
        }


    }


}
