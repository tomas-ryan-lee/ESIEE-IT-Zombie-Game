using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
            MeshRenderer mr = collision.gameObject.GetComponentInChildren<MeshRenderer>();
            if (mr)
            {
                mr.material.color = Random.ColorHSV();
            }
        }
    }
}
