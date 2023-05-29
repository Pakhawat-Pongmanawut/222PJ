using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    bool isTurnleft;
    bool isTurnright;
     float turn;
    [SerializeField] float torqueAmount = 10f;
    float baseSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

    }

    public void DisableContoller()
    {
        canMove = false;
    }

 private void MovePlayer()
    {
        if(isTurnleft) 
        {
            turn = torqueAmount;
        } 
        else if(isTurnright)
        {
            turn = -torqueAmount;
        } 
        else
        {
            turn = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
       MovePlayer();
    }
    void FixedUpdate()
    {
        rb2d.AddTorque(turn);
    }

    public void RotateLeft()
    {
        isTurnleft = true;

    }
    public void RotateRight()
    {
        isTurnright = true;

    }
    public void RotateLeftUp()
    {
        isTurnleft = false;
    }
    public void RotateRightUp()
    {
        isTurnright = false;
    }

}