using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f, Dash = 100f;
    bool PlayerDash = false;
    float L_AxisX, L_AxisY, R_AxisX, R_AxisY;
    Vector3 PlayerOrientation;
    Vector2 RightStickInput;
    private CharacterController Player;


    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Speed * L_AxisX * Time.deltaTime, Space.World);
        transform.Translate(Vector3.forward * Speed * L_AxisY * Time.deltaTime, Space.World);
        RightStickInput = new Vector2(R_AxisX, R_AxisY);
        //    DirectionDeplacement.z = Input.GetAxisRaw("Vertical");
        //    DirectionDeplacement.x = Input.GetAxisRaw("Horizontal");
        //    DirectionDeplacement = transform.TransformDirection(DirectionDeplacement);
        //    Player.Move(DirectionDeplacement * Time.deltaTime * Speed);
    }
    private void FixedUpdate()
    {
       
        if (PlayerDash)
        {
            transform.Translate(Vector3.right * Dash * L_AxisX * Time.deltaTime);
            transform.Translate(Vector3.forward * Dash * L_AxisY * Time.deltaTime);
            PlayerDash = false;
        }
        if (RightStickInput.magnitude > 0f)
        {
            Vector3 dirLook = new Vector3(RightStickInput.x, 0, RightStickInput.y).normalized;
            Quaternion PlayerRotation = Quaternion.LookRotation(dirLook, Vector3.up);

            transform.rotation = PlayerRotation;

        }

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
