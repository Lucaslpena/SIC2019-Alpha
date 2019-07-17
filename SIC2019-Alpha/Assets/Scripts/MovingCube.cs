using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

	float speed = 5f;
    int direction = 1;

    void Start()
    {
        
    }
		
    void Update()
    {
        if (transform.localPosition.x >= 5f)
            direction = -1;
        else if (transform.localPosition.x <= -5f)
            direction = 1;

        float newPosX = transform.localPosition.x + speed * direction * Time.deltaTime;
        transform.localPosition = new Vector3(newPosX, transform.localPosition.y, transform.localPosition.z);
    }
}
