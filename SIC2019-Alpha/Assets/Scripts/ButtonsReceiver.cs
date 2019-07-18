using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class ButtonsReceiver : MonoBehaviour {
	
	private OSCReciever reciever;

	public int port = 3333;

	public bool button1;
	public bool button2;
	public bool button3;
	public bool button4;

	
	// Use this for initialization
	void Start () {
		reciever = new OSCReciever();
		reciever.Open(port);
	}
	
	// Update is called once per frame
	void Update () {

	}


    protected void Start() {
        InvokeRepeating ("GetData", 0f, .1);
    }

    void getData(){
        if(reciever.hasWaitingMessages()){
    			OSCMessage msg = reciever.getNextMessageAndClear();
    			Debug.Log(msg.Data[0]);

    Debug.Log( msg.Data[0].GetType() );



                var result = System.Convert.ToString(System.Convert.ToInt32(msg.Data[0]), 2);
                button1 = result.Substring(0,1) == "1" ? true : false;
                button2 = result.Substring(1,1) == "1" ? true : false;
                button3 = result.Substring(2,1) == "1" ? true : false;
                button4 = result.Substring(3,1) == "1" ? true : false;
    		}
    }


}
