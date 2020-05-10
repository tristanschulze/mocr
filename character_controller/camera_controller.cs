using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
   
   public GameObject mycam;
   public GameObject target;
    
    public Vector3 focus_offset; // offset within the player body
    public Vector3 cam_offset; // camera position

    public Vector3 tpos;

    private Vector3 cpos;

    private Quaternion crot;

    public float cam_move_speed = .1f;

    public float cam_rotation_speed = 1f;
   
   
    // Start is called before the first frame update
    void Start()
    {

        cam_offset = mycam.transform.position; // get the current offset of the cam and save it!
        cpos = mycam.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        

        tpos = target.transform.position; // position of cam

        tpos +=  target.transform.forward*cam_offset.z;
        tpos += new Vector3(0,cam_offset.y,0);

        cpos = Vector3.Slerp(cpos,tpos,cam_move_speed);
        mycam.transform.position = cpos; 



        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - mycam.transform.position+focus_offset);
        crot = Quaternion.Slerp(crot,targetRotation,cam_rotation_speed);
        mycam.transform.rotation = crot;

     
      


    }
}
