using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using LitJson;
using System;

/**
 * Class that acts as a client for MIDAS, sending requests.
 * In general, only one instance of this class is necessary.
 * It sends requests to the MidasAddress specified, using the
 * MidasRequest specified, returning the result.
 */
public class MidasClient : MonoBehaviour
{
    /**
	 * Private function for performing a request.
	 * Sends the MidasRequest to the dispatcher at MidasAddress.
	 * 
	 * @param address Address of the MIDAS dispatcher
	 * @param request Request to be performed to the MIDAS dispatcher
	 * @return Response (all of it) of the dispatcher as JsonData
	 */
    private JsonData PerformRequest(MidasAddress address, MidasRequest request)
    {
        // Perform the request
        string response = new WebClient().DownloadString(address.address + request.request);

        // Format the JSON string appropriately
        response = response.Replace("[{", "{").Replace("}]", "}"); // Remove the starting and ending brackets so that LitJson can parse it

        // Deserialize the JSON to an object
        return JsonMapper.ToObject(response);
    }

    private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e, MidasListener midasListener)
    {
        string response = e.Result;

        // Format the JSON string appropriately
        response = response.Replace("[{", "{").Replace("}]", "}"); // Remove the starting and ending brackets so that LitJson can parse it

        // Deserialize the JSON to an object
        JsonData data = JsonMapper.ToObject(response);

        double[] res;
        // Put the data into an array
        if (data["return"].IsArray)
        {
            res = new double[data["return"].Count];
            for (int i = 0; i < data["return"].Count; i++)
            {
                res[i] = (double)data["return"][i];
            }
        }
        else
        {
            res = new double[] { (double)data["return"] };
        }

        // Return the data array
        midasListener.SetClientData(res);
    }

    private void PerformRequestAsync(MidasListener midasListener, MidasAddress address, MidasRequest request)
    {
        // Perform the request
        WebClient wc = new WebClient();
        wc.DownloadStringCompleted += (sender, e) => wc_DownloadStringCompleted(sender, e, midasListener);
        wc.DownloadStringAsync(new Uri(address.address + request.request));
    }

    /**
	 * Uses PerformRequest the MidasRequest to the dispatcher at MidasAddress.
	 * It returns the result as an array of double.
	 * 
	 * @param address Address of the MIDAS dispatcher
	 * @param request Request to be performed to the MIDAS dispatcher
	 * @return Result of the request as an array of double
	 */
    public void SendRequest(MidasListener midasListener, MidasAddress address, MidasRequest request)
    {
        // Get the response as JsonData
        //JsonData data = PerformRequestAsync(address, request);
        PerformRequestAsync(midasListener, address, request);
    }

    /**
	 * Uses PerformRequest the MidasRequest to the dispatcher at MidasAddress.
	 * It returns the result as a raw JsonData that will have to be
	 * manually casted to its natural data type by the caller.
	 * This is to be used for request responses that are not single numbers.
	 * 
	 * @param address Address of the MIDAS dispatcher
	 * @param request Request to be performed to the MIDAS dispatcher
	 * @return Result of the request as JsonData
	 */
    public JsonData SendRequestRaw(MidasAddress address, MidasRequest request)
    {
        // Get the response as JsonData
        JsonData data = PerformRequest(address, request);

        // Return the "return" data
        return data["return"];
    }
}
