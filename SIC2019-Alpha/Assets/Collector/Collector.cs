using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    struct Reading{
        public double[] eegData;
        public int serial;
    }

    private static Collector _instance;
    public static Collector Instance { get { return _instance; } }

    public int HRV;




   public double repeatFrecuencySeconds;
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


    public void GetData()
    {
        Reading r;
        double[] recentAffective = midasListener.data;
        r.eegData= recentAffective);

        /** Here we will get data from Alayna
        and add it to the dictionary object... we need to change the dictionary object

            r.serial = // alaynas input //


            ..
             doing daa stuff ere

        **/

        HRV = r.eegData[0]; //this is fake and obviously should be tarnsformed in something mentioned above...
    }
    protected void Start() {
        InvokeRepeating ("GetData", 0f, repeatFrecuencySeconds);
    }
}