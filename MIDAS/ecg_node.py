#!/usr/bin/env python3

import sys
import numpy as np
import heartpy

from midas.node import BaseNode
from midas import utilities as mu

def _mean_hr_heartpy(x, sampling_rate):
        print("computing mean_hr_heartpy")
        working_data, measures = heartpy.process(np.array(x), sample_rate=sampling_rate)
        print(measures['bpm'])
        return measures['bpm']


# ECG processing node
class ECGNode(BaseNode):

    def __init__(self, *args):
        """ Initialize ECG node. """
        super().__init__(*args)

        # Append function handles to the metric_functions-list
        self.metric_functions.append(self.mean_hr)
        self.metric_functions.append(self.mean_hr_heartpy)
        self.metric_functions.append(self.computeChangeHRV)

    def mean_hr(self, x):
        """ Calculate the average heart rate
            from the raw ECG signal x by first
            obtaining the RR-intervals using
            R-peak detection.
        """
        print("computing mean_hr")
        rr = ecg_utilities.detect_r_peaks(x['data'][0],
                                          self.primary_sampling_rate)
        return ecg_utilities.hrv_mean_hr(rr)
    
    def mean_hr_heartpy(self, x):
        print("computing mean_hr_heartpy")
        working_data, measures = heartpy.process(np.array(x['data'][0]), sample_rate=self.primary_sampling_rate)
        print(measures['bpm'])
        return measures['bpm']
    
    def computeChangeHRV(self, x):
        """ Returns the change in HRV, computed using averages of HRV of two overlapping time windows. """
        """ It uses a short window and a long window and compares the difference. """
        """ The long window has to be equal or shorther than the time window that """
        """ this function receives (usually equal), and the short window has to be """
        """ equal or shorter than the long window (usually shorter). """
        short_time_window = 10 # seconds
        long_time_window = 30 # seconds
        
        data_long = x['data'][0]
        data_short = data_long[len(data_long) - int(len(data_long)*(short_time_window/long_time_window)):]
        
        if len(data_short) > 0 and len(data_long) > 0:
            print("computing change in HR")
            return _mean_hr_heartpy(data_short, self.primary_sampling_rate) / _mean_hr_heartpy(data_long, self.primary_sampling_rate)
        else:
            return 0


# Run the node from command line
if __name__ == '__main__':
    node = mu.midas_parse_config(ECGNode, sys.argv)
    if node:
        node.start()
        node.show_ui()
