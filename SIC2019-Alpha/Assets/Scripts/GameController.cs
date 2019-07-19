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
    private bool lastCube;
    private bool currentCube; 

    public int Streak;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Streak = 0;
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
        // if done to check the distance and assign point based on the distance
        if(distance <= distancePerfect)
        {
            lastCube = currentCube;
            currentCube = true;

            Debug.Log("Perfect");

            score += 2;
            if(lastCube && currentCube)
            {
                Streak++;
            }
        } else if (distance <= distanceGood && distance > distancePerfect)
        {
            currentCube = false;
            Streak = 0;
            Debug.Log("Good");
            score++;
        } else
        {
            currentCube = false;
            Streak = 0;
            score--;
            Debug.Log("Bad");
        }
        UiController.UpdateText(score);
    }

    private void OnPushHatsO()
    {
            BeatController.HatO.gameObject.GetComponent<Animator>().SetTrigger("buttonPressed");
        if (BeatController._hatsO.Count > 0)
        {
            GameObject g = BeatController._hatsO[0];
            GetDistanceFromTarget(g.transform, BeatController.HatO);
            BeatController.DisposeCube(g, 0);
            Destroy(g);
        }
    }

    private void OnPushSnares()
    {
            BeatController.Snare.gameObject.GetComponent<Animator>().SetTrigger("buttonPressed");
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
            BeatController.Kick.gameObject.GetComponent<Animator>().SetTrigger("buttonPressed");
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
            BeatController.HatC.gameObject.GetComponent<Animator>().SetTrigger("buttonPressed");
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
