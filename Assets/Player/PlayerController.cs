using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float Speed;
    [SerializeField] public float Dash;
    [SerializeField] public float RotationSpeed;


    bool PlayerDash = false;
    float L_AxisX, L_AxisY, R_AxisX, R_AxisY;
    Vector3 PlayerOrientation;
    Vector2 RightStickInput;
    Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    //void update()
    //{
    //    transform.translate(vector3.right * speed * l_axisx * time.deltatime, space.world);
    //    transform.translate(vector3.forward * speed * l_axisy * time.deltatime, space.world);
    //    rightstickinput = new vector2(r_axisx, r_axisy);
    //        directiondeplacement.z = input.getaxisraw("vertical");
    //       directiondeplacement.x = input.getaxisraw("horizontal");
    //       directiondeplacement = transform.transformdirection(directiondeplacement);
    //       player.move(directiondeplacement * time.deltatime * speed);
    //}
    private void FixedUpdate()
    {
        RightStickInput = new Vector2(R_AxisX, R_AxisY);
        //redressement

        if (PlayerDash)
        {


            //transform.Translate(Vector3.right * Dash * L_AxisX * Time.deltaTime);
            //transform.Translate(Vector3.forward * Dash * L_AxisY * Time.deltaTime);

            PlayerDash = false;
        }
        if (RightStickInput.magnitude > 0f)
        {





        ////    Vector3 dirLook = new Vector3(RightStickInput.x, 0, RightStickInput.y).normalized;
        ////    Quaternion PlayerRotation = Quaternion.LookRotation(dirLook, Vector3.up);

        ////    transform.rotation = PlayerRotation;

        }

        // Mode POSITION & ORIENTATION -> TELEPORTATION
        //// on demande à atteindre une certaine position & orientation
        Vector3 newRequestedPosY = rb.position + L_AxisY * transform.forward * Speed * Time.fixedDeltaTime;
        rb.MovePosition(newRequestedPosY);
        Vector3 newRequestedPosX = rb.position + L_AxisX * transform.right * Speed * Time.fixedDeltaTime;
        rb.MovePosition(newRequestedPosX);


        //redressement
        Quaternion qSlightlyUpright = Quaternion.Lerp(rb.rotation,
            Quaternion.FromToRotation(transform.up, Vector3.up) * rb.rotation,
            Time.fixedDeltaTime * 4);

       float rotAngle = R_AxisX * RotationSpeed * Time.fixedDeltaTime;
       Quaternion qRot = Quaternion.AngleAxis(rotAngle, transform.up);


        //synthèse
        Quaternion qNewOrientation = qRot * qSlightlyUpright;
        rb.MoveRotation(qNewOrientation);

        rb.AddForce(-rb.velocity, ForceMode.VelocityChange);
       rb.AddTorque(-rb.angularVelocity, ForceMode.VelocityChange);



    }


    public void OnDash()
    {
        PlayerDash = true;
    }
    public void OnHorizontal(InputValue val)
    {
        L_AxisX = val.Get<float>();
    }
    public void OnVertical(InputValue val)
    {
        L_AxisY = val.Get<float>();
    }
    public void OnTurnX(InputValue val)
    {
        R_AxisX = val.Get<float>();
    }
    public void OnTurnY(InputValue val)
    {
        R_AxisY = val.Get<float>();
    }
}
