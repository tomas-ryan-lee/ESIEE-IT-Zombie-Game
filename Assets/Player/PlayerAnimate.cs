using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{

    float speed = 4;
    float rotSpeed = 80;
    float gravity = 8;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)){
            anim.SetInteger("vertical", 1);
            Debug.Log("Vertical");
        }
        if(Input.GetKeyUp(KeyCode.Z)){
            anim.SetInteger("vertical", 0);
        }
    }
}
