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

    public ButtonsReceiver ButtonReceiver;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonReceiver.button1)
        {
            OnPushHatsO();
        }
        if (ButtonReceiver.button2)
        {
            OnPushSnares();
        }
        if (ButtonReceiver.button3)
        {
            OnPushKicks();
        }
        if (ButtonReceiver.button4)
        {
            OnPushHatsC();
        }
    }

}
