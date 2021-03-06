﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    private Vector3 _stopPosition;
    private BeatController _beatController;
    private LineRenderer _lineRenderer;
    public int cubeType { get; private set; }

    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        //if(cubeType == 0)
        //{
        //    _lineRenderer = this.GetComponent<LineRenderer>();
        //}
        _beatController = GameObject.Find("BeatController").GetComponent<BeatController>();
        // store the position of stop taking it from the empty gameobject that is in the scene
        _stopPosition = new Vector3(this.transform.position.x, this.transform.position.y, -105f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerPosition();
        if(transform.position.z < -104.5f)
        {
            DeleteCube();
        }
    }

    private void UpdatePlayerPosition()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, _stopPosition,  Time.deltaTime * _beatController.Tempo * 8);
    }

    private void UpdateLineRenderer()
    {
        _lineRenderer.SetPosition(0, this.transform.position);
        _lineRenderer.SetPosition(1, _beatController.HatO.position);
    }

    public void SetCubeType(int cubeType)
    {
        this.cubeType = cubeType;
    }

    private void DeleteCube()
    {
        _beatController.DisposeCube(this.gameObject, cubeType);
    }

}
