using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float Speed;
    [SerializeField] public float Dash;
    [SerializeField] public float RotationSpeed;


    //ball
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_BallSpawnPositionFront;
    [SerializeField] Transform m_BallSpawnPositionLeft;
    [SerializeField] Transform m_BallSpawnPositionRight;
    [SerializeField] float m_BallStartSpeed;
    [SerializeField] float m_BallLifeDuration;

    [SerializeField] float m_ShootingPeriod;
    float m_NextShootTime;


    bool PlayerDash = false;
    float L_AxisX, L_AxisY, R_AxisX, R_AxisY;
    Vector3 PlayerOrientation;
    Vector2 RightStickInput;
    Rigidbody rb;

    void Shoot1Ball()
    {
        GameObject newBallGO = Instantiate(m_BallPrefab);
        newBallGO.transform.position = m_BallSpawnPositionFront.position;
        newBallGO.GetComponent<Rigidbody>().velocity = m_BallSpawnPositionFront.forward * m_BallStartSpeed;
        Destroy(newBallGO, m_BallLifeDuration);
    }
    void Shoot3Ball()
    {
        GameObject newBallGOFront = Instantiate(m_BallPrefab);
        GameObject newBallGOLeft = Instantiate(m_BallPrefab);
        GameObject newBallGORight = Instantiate(m_BallPrefab);
        newBallGOFront.transform.position = m_BallSpawnPositionFront.position;
        newBallGOLeft.transform.position = m_BallSpawnPositionLeft.position;
        newBallGORight.transform.position = m_BallSpawnPositionRight.position;
        newBallGOFront.GetComponent<Rigidbody>().velocity = m_BallSpawnPositionFront.forward * m_BallStartSpeed;
        newBallGOLeft.GetComponent<Rigidbody>().velocity = m_BallSpawnPositionLeft.forward * m_BallStartSpeed;
        newBallGORight.GetComponent<Rigidbody>().velocity = m_BallSpawnPositionRight.forward * m_BallStartSpeed;
        Destroy(newBallGOFront, m_BallLifeDuration);
        Destroy(newBallGOLeft, m_BallLifeDuration);
        Destroy(newBallGORight, m_BallLifeDuration);
    }



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
        //// on demande � atteindre une certaine position & orientation
        Animator animator;
        Vector3 newRequestedPosY = rb.position + L_AxisY * transform.forward * Speed * Time.fixedDeltaTime;
        rb.MovePosition(newRequestedPosY);
        Vector3 newRequestedPosX = rb.position + L_AxisX * transform.right * Speed * Time.fixedDeltaTime;
        rb.MovePosition(newRequestedPosX);


        //redressement
        Quaternion qSlightlyUpright = Quaternion.Lerp(rb.rotation,
            Quaternion.FromToRotation(transform.up, Vector3.up) * rb.rotation,
            Time.fixedDeltaTime * 4);

        Vector3 dirLook = new Vector3(RightStickInput.x, 0, RightStickInput.y).normalized;
        float rotAngle = R_AxisX * RotationSpeed * Time.fixedDeltaTime;
        Quaternion qRot = Quaternion.LookRotation(dirLook, transform.up);


        //synth�se
        Quaternion qNewOrientation = qRot * qSlightlyUpright;
        rb.MoveRotation(qRot);

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
    public void OnFire1()
    {
        // FIRE base
        if ( Time.time > m_NextShootTime)
        {
            Shoot1Ball();
            m_NextShootTime = Time.time + m_ShootingPeriod;
        }

    }

    public void OnFire2()
    {
        // FIRE Shotgun
        if ( Time.time > m_NextShootTime)
        {
            Shoot3Ball();
            m_NextShootTime = Time.time + m_ShootingPeriod;
        }

    }
}
