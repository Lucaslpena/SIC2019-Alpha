using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Change the name of this class to the true usage (e.g. ArousalListener)
public class GenericListener : MidasListener {

	// Change the name of this variable to the true data meaning (e.g. arousal), if necessary
	double genericData;

	new void Start () {
		base.Start ();
	}
		
	void Update () {
		// Only if the listener gets data automatically
		if (repeat)
			genericData = data [0];
	}

	// Change the name of this function to the true data meaning (e.g. GetArousal)
	public double GetGenericData () {
		// If we want to get data on demand at any specific moment
		return base.GetClientData () [0];
	}
}
