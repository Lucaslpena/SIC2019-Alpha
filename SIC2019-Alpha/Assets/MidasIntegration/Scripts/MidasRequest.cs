using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for holding a request for the Midas dispatcher.
 * It is used in combination with MidasAddress for sending
 * requests to the Midas dispatcher using a MidasClient.
 * 
 * There will be an instance of this class for each different
 * request that is performed.
 * 
 * It has variables for setting every possible request value (see MIDAS API).
 * These variables are asigned from the inspector.
 */
public class MidasRequest : MonoBehaviour {

	public string nodeName = "ecgnode";					/**< Name of the node */
	public string messageType = "metric";				/**< Type of message. 'metric', 'data' or 'command' */
	public string metricType = "mean_hr";				/**< Metric type (name of metric function in the node) */
	public string[] channels = new string[] {"ch0"};	/**< List of channels to be used in the request */
	public int[] time_window = new int[2] {15, 0};		/**< Time window as an array of TWO values in seconds: starting moment and duration */
	public double[] arguments = new double[] { };		/**< Additional arguments */

	[System.NonSerialized]
	public string request = "";

	/**
	 * Formats the address by combining the different arguments.
	 * The result is like '/ecgnode/metric/{"type":"mean_hr","channels":["ch0"],"time_window":[15]}'.
	 */
	private void FormatRequest() {
		// Check that it has the two fundamental components
		if (nodeName != "" && messageType != "") {
			// Formate the base with nodeName and messageType
			request = "/" + nodeName + "/" + messageType + "/{";

			// Add request arguments
			// Add metric type, if any
			if (metricType != "") {
				request += "\"type\":\"" + metricType + "\",";
			}
			// Add channels, if any
			if (channels.Length > 0) {
				request += "\"channels\":[";
				foreach (string ch in channels) {
					request += "\"" + ch + "\",";
				}
				request = request.TrimEnd(','); // Remove last comma
				request += "],";
			}
			// Add time window, if any
			if (time_window.Length > 0) {
				request += "\"time_window\":[" + time_window[0];
				if (time_window.Length == 2 && time_window [1] != 0) {
					request += "," + time_window [1];
				}
				request += "],";
			}
			// Add arguments, if any
			if (arguments.Length > 0) {
				request += "\"arguments\":[";
				foreach (double arg in arguments) {
					request += arg.ToString() + ",";
				}
				request = request.TrimEnd(','); // Remove last comma
				request += "],";
			}
			request = request.TrimEnd(','); // Remove last comma
			request += "}";
		}
	}

	public void Start() {
		FormatRequest ();
	}
}
