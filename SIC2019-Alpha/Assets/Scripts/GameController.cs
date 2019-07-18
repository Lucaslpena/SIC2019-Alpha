using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float distancePerfect;
    public float distanceGood;
    public float distanceBad;

    public BeatController BeatController;
    public UIController UiController;

    private int score;
    public int Streak;
    private int lastCube;
    private int currentCube; 

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        InputManager.OnPushHatsO += OnPushHatsO; 
        InputManager.OnPushSnares += OnPushSnares; 
        InputManager.OnPushKicks += OnPushKicks; 
        InputManager.OnPushHatsC += OnPushHatsC; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetDistanceFromTarget(Transform cube, Transform target)
    {
        UpdateScore(Vector3.Distance(cube.position, target.position));
    }

    private void UpdateScore(float distance)
    {
        Debug.Log(distance);
        // if done to check the distance and assign point based on the distance
        if(distance <= distancePerfect)
        {
            Debug.Log("Perfect");
            score += 2;
        } else if (distance <= distanceGood && distance > distancePerfect)
        {
            Debug.Log("Good");
            score++;
        } else
        {
            score--;
            Debug.Log("Bad");
        }
        UiController.UpdateText(score);
    }

    private void OnPushHatsO()
    {
        if (BeatController._hatsO.Count > 0)
        {
            GameObject g = BeatController._hatsO[0];
            GetDistanceFromTarget(g.transform, BeatController.HatO);
            BeatController.DisposeCube(g, 0);
        }
    }

    private void OnPushSnares()
    {
        if (BeatController._snares.Count > 0)
        {
            GameObject g = BeatController._snares[0];
            GetDistanceFromTarget(g.transform, BeatController.Snare);
            BeatController.DisposeCube(g, 1);
            Destroy(g);
        }
    }

    private void OnPushKicks()
    {
        if (BeatController._kicks.Count > 0)
        {
            GameObject g = BeatController._kicks[0];
            GetDistanceFromTarget(g.transform, BeatController.Kick);
            BeatController.DisposeCube(g, 2);
            Destroy(g);
        }
    }

    private void OnPushHatsC()
    {
        if (BeatController._hatsC.Count > 0)
        {
            GameObject g = BeatController._hatsC[0];
            GetDistanceFromTarget(g.transform, BeatController.HatC);
            BeatController.DisposeCube(g, 3);
            Destroy(g);
        }
    }

    private void UpdateStreak()
    {

    }



}
