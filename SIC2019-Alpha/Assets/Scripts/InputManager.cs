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

    public ButtonsReceiver ButtonsReceiver;

    public bool UseKeyboard, UseButtons, UseMidi;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (UseButtons)
        {
            UpdateButtons();
        } else if (UseKeyboard)
        {
            UpdateKeyboard();
        } else
        {
            UpdateMidi();
        }
    }

    private void UpdateKeyboard()
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

    private void UpdateButtons()
    {
        if (ButtonsReceiver.button1)
        {
            OnPushHatsO();
        }
        if (ButtonsReceiver.button2)
        {
            OnPushSnares();
        }
        if (ButtonsReceiver.button3)
        {
            OnPushKicks();
        }
        if (ButtonsReceiver.button4)
        {
            OnPushHatsC();
        }
    }

    private void UpdateMidi()
    {

        if (MidiJack.MidiMaster.GetKeyDown(0, 48))
        {
            OnPushHatsO();
        }
        if (MidiJack.MidiMaster.GetKeyDown(0, 49))
        {
            OnPushSnares();
        }
        if (MidiJack.MidiMaster.GetKeyDown(0, 50))
        {
            OnPushKicks();
        }
        if (MidiJack.MidiMaster.GetKeyDown(0, 51))
        {
            OnPushHatsC();
        }
    }

}
