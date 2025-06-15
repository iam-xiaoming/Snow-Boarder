using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float normalSpeed = 15f;
    Rigidbody2D rgb2D;
    SurfaceEffector2D surfaceEffector2D;
    bool canControl = true;

    // Start is called before the first frame update
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
            Rotate();
            SpeedResponse();
        }
    }

    public void DisableControl()
    {
        canControl = false;
    }

    void SpeedResponse()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rgb2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rgb2D.AddTorque(-torqueAmount);
        }
    }
}
