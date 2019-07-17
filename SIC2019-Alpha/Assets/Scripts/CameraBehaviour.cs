using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    public Transform Player;
    private float _smoothSpeed = 0.125f;
    private Vector3 _offset;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateCameraPosition();
    }

    /// <summary>
    /// method called during the LateUpdate to move the camera from the starting position of the scenario to the final position.
    /// </summary>
    private void UpdateCameraPosition()
    {
        Vector3 desiredPosition = Player.position + _offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = Vector3.SmoothDamp(this.transform.position, desiredPosition, ref velocity, _smoothSpeed);

        transform.LookAt(Player);
    }
}
