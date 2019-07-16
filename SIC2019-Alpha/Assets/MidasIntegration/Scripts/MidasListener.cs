using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class that receives data from MIDAS using a client.
 * It sends a request to MIDAS every 15 seconds.
 * 
 * Every listener will inherit from this class.
 */
abstract public class MidasListener : MonoBehaviour {

	public MidasClient midasClient;
	public MidasAddress midasAddress;
	public MidasRequest midasRequest;

	public bool repeat = true;
	public float repeatFrecuencySeconds = 15f;

	// Fields for the data obtained with the request (e.g., heart rate)
	[System.NonSerialized]
	public double[] data;

	protected double[] GetClientData () {
		// Get the data using the client to send the request to the MIDAS address
		data = midasClient.SendRequest (midasAddress, midasRequest);
		return data;
	}

	protected void Start() {
		// Perform a request every few seconds, specified by repeatFrecuencySeconds
		if (repeat)
			InvokeRepeating ("GetClientData", 0f, repeatFrecuencySeconds);
	}
}
