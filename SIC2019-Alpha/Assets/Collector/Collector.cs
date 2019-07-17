using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    struct Reading {
        public double[] ecgData;
        public int serial;
    }

    private static Collector _instance;
    public static Collector Instance { get { return _instance; } }

    public double HRV;

   	public float repeatFrecuencySeconds;
    public MidasListener midasListener;


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
        Debug.Log(HRV);
    }


    public void GetData()
    {
        Reading r;
        double[] recentAffective = midasListener.data;
        r.ecgData = recentAffective;

        /** Here we will get data from Alayna
        and add it to the dictionary object... we need to change the dictionary object

            r.serial = // alaynas input //


            ..
             doing daa stuff ere

        **/

        if (r.ecgData != null && r.ecgData.Length > 0)
            HRV = r.ecgData[0]; //this is fake and obviously should be tarnsformed in something mentioned above...
    }

    protected void Start() {
        InvokeRepeating ("GetData", 0f, repeatFrecuencySeconds);
    }
}