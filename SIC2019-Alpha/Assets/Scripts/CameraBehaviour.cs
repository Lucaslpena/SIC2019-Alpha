using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    private float _speed;
    private Vector3 _startPosition;
    private Vector3 _stopPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = _startPosition;
        _stopPosition = _startPosition + new Vector3(0, 0, 5000f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, _stopPosition, Time.deltaTime);   
    }

}
