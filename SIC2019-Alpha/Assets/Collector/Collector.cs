using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    private static Collector _instance;
    public static Collector Instance { get { return _instance; } }


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



    public void GetData()
    {
        Debug.Log(midasListener.data[0]);
    }

    void Update() {
//        GetData();
    }

    protected void Start() {
        InvokeRepeating ("GetData", 0f, repeatFrecuencySeconds);
    }
}