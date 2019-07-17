using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public delegate void PushButton();
    public static event PushButton OnPushHatsO;
    public static event PushButton OnPushSnares;
    public static event PushButton OnPushKicks;
    public static event PushButton OnPushHatsC;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            OnPushHatsO();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            OnPushSnares();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            OnPushKicks();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            OnPushHatsC();
        }
    }

}
