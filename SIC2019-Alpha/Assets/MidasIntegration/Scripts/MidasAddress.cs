using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class for holding the address of the MIDAS dispatcher.
 * It is used in combination with MidasRequest for sending
 * requests to the Midas dispatcher using a MidasClient.
 * 
 * There can be either one instance of this class, if all requests
 * go to the same dispatcher, or several, if more dispatchers are used.
 * 
 * It has a variable for the IP address and another for the port.
 * These values are asigned from the inspector.
 * It has a method for formatting it like 'http://127.0.0.1:8080'.
 */
public class MidasAddress : MonoBehaviour {

	public string ip = "127.0.0.1";	/**< IP of the MIDAS dispatcher */
	public string port = "8080"; 	/**< Port of the MIDAS dispatcher */

	[System.NonSerialized]
	public string address = "";

	/**
	 * Formats the address by combining the IP and the port.
	 * The result is like 'http://127.0.0.1:8080'.
	 */
	private void FormatAddress() {
		// Format address if specified from inspector
		if (ip != "" && port != "") {
			address = "http://" + ip + ":" + port;
		} else {
			Debug.Log ("Midas address missing");
		}
	}

	public void Start() {
		FormatAddress ();
	}
}
