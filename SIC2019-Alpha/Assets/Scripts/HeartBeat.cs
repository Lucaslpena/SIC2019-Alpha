using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour {

	public Collector collector;

	private const float pctToContracted = 0.2f; // Percentage of the beat for contraction
	private const float pctToExpanded = 0.8f; // Percentage of the beat for expansion
	private Vector3 heartSizeContracted;
	private Vector3 heartSizeExpanded;
	private float secondsBetweenBeats;

	void Awake () {
		heartSizeContracted = transform.localScale;
		heartSizeExpanded = heartSizeContracted * 1.1f;
	}
	
	void Update () {
        if (collector.HR > 0)
        {
            secondsBetweenBeats = 60f / (float)collector.HR;
            if (transform.localScale.magnitude >= heartSizeExpanded.magnitude)
            {
                Debug.Log("ANIMATION TO CONTRACT");
                StartCoroutine(BeatHeart(heartSizeContracted, secondsBetweenBeats * pctToContracted));
            }
            else if (transform.localScale.magnitude <= heartSizeContracted.magnitude)
            {
                Debug.Log("ANIMATION TO EXPAND");
                StartCoroutine(BeatHeart(heartSizeExpanded, secondsBetweenBeats * pctToExpanded));
            }
        }
	}

	public IEnumerator BeatHeart(Vector3 targetSize, float transitionDuration) {
		Vector3 initialSize = transform.localScale;
		float rate = 1f / transitionDuration;
		float t = 0f;
		while (t < 1f) {
			t += Time.deltaTime * rate;
			transform.localScale = Vector3.Lerp (initialSize, targetSize, t);
			yield return 0;
		}
	}
}
