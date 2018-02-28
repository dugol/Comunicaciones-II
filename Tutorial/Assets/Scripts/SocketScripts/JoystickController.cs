using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour {

    public static JoystickController singleton;

    public delegate void OnMove(Vector3 vec3);
    public event OnMove OnCommandMove;

    public WachButton Left;
    public WachButton Right;
    public WachButton Backward;
    public WachButton Forward;

    public GameObject playerObj;

    Login login;

    public bool leftMove;
    public bool rightMove;
    public bool backMove;
    public bool frontMove;

    void Start()
    {
        playerObj = new GameObject();
        singleton = this;
    }

     public void ActionJoystick()
    {
        Left.OnPress += OnPress;
        Right.OnPress += OnPress;
        Backward.OnPress += OnPress;
        Forward.OnPress += OnPress;
    }

    void OnPress(GameObject unit, bool state)
    {
        switch(unit.name)
        {
            case "Left":
                LeftMove(state);
                break;
            case "Right":
                RightMove(state);
                break;
            case "Backward":
                BackMove(state);
                break;
            case "Forward":
                FrontMove(state);
                break;
        }
        Debug.Log(unit.name);
    }

    private void LeftMove(bool state)
    {
        leftMove = state;
    }

    private void RightMove(bool state)
    {
        rightMove = state;
    }

    private void BackMove(bool state)
    {
        backMove = state;
    }

    private void FrontMove(bool state)
    {
        frontMove = state;
    }

    void Update()
    {
        Transform tranf = playerObj.transform;
        

        if (leftMove)
        {
            playerObj.transform.position = new Vector3(tranf.position.x - (2f * Time.deltaTime), tranf.position.y, tranf.position.z);
           
            if(OnCommandMove != null)
            {
                OnCommandMove(playerObj.transform.position);
            }
        }
        if (rightMove)
        {
            playerObj.transform.position = new Vector3(tranf.position.x + (2f * Time.deltaTime), tranf.position.y, tranf.position.z);
            if (OnCommandMove != null)
            {
                OnCommandMove(playerObj.transform.position);
            }
        }
        if (backMove)
        {
            playerObj.transform.position = new Vector3(tranf.position.x, tranf.position.y, tranf.position.z -(2f*Time.deltaTime));
            if (OnCommandMove != null)
            {
                OnCommandMove(playerObj.transform.position);
            }
        }
        if (frontMove)
        {
            playerObj.transform.position = new Vector3(tranf.position.x , tranf.position.y, tranf.position.z + (2f * Time.deltaTime));
            if (OnCommandMove != null)
            {
                OnCommandMove(playerObj.transform.position);
            }
        }
    }
    
}
