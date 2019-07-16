using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    private static Collector _instance;
    public static Collector Instance { get { return _instance; }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        getData();
    }

    public MidasListener midasListener;


    public void getData()
    {
        Debug.Log(midasListener.data[0]);
    }
}