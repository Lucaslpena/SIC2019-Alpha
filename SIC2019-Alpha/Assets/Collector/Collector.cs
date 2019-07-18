using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    /*struct Reading {
        public double[] ecgData;
        public int serial;
    }*/

    private static Collector _instance;
    public static Collector Instance { get { return _instance; } }

    public double HR;
    public double IBI;
    public double SDNN;
    public double changeHR;
    public double changeIBI;
    public double changeSDNN;

   	public float repeatFrecuencySeconds;
    public MidasListener midasHRListener;
    public MidasListener midasIBIListener;
    public MidasListener midasSDNNListener;
    public MidasListener midasChangeHRListener;
    public MidasListener midasChangeIBIListener;
    public MidasListener midasChangeSDNNListener;

    public bool printData;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private void Update()
    {
        if (printData) {
            Debug.Log("HR: " + HR);
            Debug.Log("IBI: " + IBI);
            Debug.Log("SDNN: " + SDNN);
            Debug.Log("Change HR: " + changeHR);
            Debug.Log("Change IBI: " + changeIBI);
            Debug.Log("Change SDNN: " + changeSDNN);
        }
    }

    /*
    public void GetData()
    {
        Reading r;
        double[] recentAffective = midasHRListener.data;
        r.ecgData = recentAffective;

        /** Here we will get data from Alayna
        and add it to the dictionary object... we need to change the dictionary object

            r.serial = // alaynas input //


            ..
             doing daa stuff ere

        **/
        /*
        if (r.ecgData != null && r.ecgData.Length > 0)
            HRV = r.ecgData[0]; //this is fake and obviously should be tarnsformed in something mentioned above...
        HRV = midasHRListener.data[0];
    }*/

    public void GetData()
    {
        if (midasHRListener != null && midasHRListener.data != null && midasHRListener.data.Length > 0)
            HR = midasHRListener.data[0];
        if (midasIBIListener != null && midasIBIListener.data != null && midasIBIListener.data.Length > 0)
            IBI = midasIBIListener.data[0];
        if (midasSDNNListener != null && midasSDNNListener.data != null && midasSDNNListener.data.Length > 0)
            SDNN = midasSDNNListener.data[0];
        if (midasChangeHRListener != null && midasChangeHRListener.data != null && midasChangeHRListener.data.Length > 0)
            changeHR = midasChangeHRListener.data[0];
        if (midasChangeIBIListener != null && midasChangeIBIListener.data != null && midasChangeIBIListener.data.Length > 0)
            changeIBI = midasChangeIBIListener.data[0];
        if (midasChangeSDNNListener != null && midasChangeSDNNListener.data != null && midasChangeSDNNListener.data.Length > 0)
            changeSDNN = midasChangeSDNNListener.data[0];
    }


    protected void Start() {
        InvokeRepeating ("GetData", 0f, repeatFrecuencySeconds);
    }
}