#!/usr/bin/env python3

import sys
import numpy as np
import heartpy

from midas.node import BaseNode
from midas import utilities as mu

def _mean_hr(x, sampling_rate):
    print("computing mean_hr")
    working_data, measures = heartpy.process(np.array(x), sample_rate=sampling_rate)
    print(measures['bpm'])
    return measures['bpm']

def _mean_ibi(x, sampling_rate):
    print("computing mean_ibi")
    working_data, measures = heartpy.process(np.array(x), sample_rate=sampling_rate)
    print(measures['ibi'])
    return measures['ibi']


# ECG processing node
class ECGNode(BaseNode):

    def __init__(self, *args):
        """ Initialize ECG node. """
        super().__init__(*args)

        # Append function handles to the metric_functions-list
        self.metric_functions.append(self.mean_hr)
        self.metric_functions.append(self.mean_ibi)
        self.metric_functions.append(self.change_hr)
        self.metric_functions.append(self.change_ibi)
    
    def mean_hr(self, x):
        print("computing mean_hr")
        working_data, measures = heartpy.process(np.array(x['data'][0]), sample_rate=self.primary_sampling_rate)
        print(measures['bpm'])
        return measures['bpm']
    
    def mean_ibi(self, x):
        print("computing mean_ibi")
        working_data, measures = heartpy.process(np.array(x['data'][0]), sample_rate=self.primary_sampling_rate)
        print(measures['ibi'])
        return measures['ibi']
    
    def change_hr(self, x):
        """ Returns the change in HR, computed using averages of HR of two overlapping time windows. """
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
            return _mean_hr(data_short, self.primary_sampling_rate) / _mean_hr(data_long, self.primary_sampling_rate)
        else:
            return 0
        
    def change_ibi(self, x):
        """ Returns the change in IBI, computed using averages of IBI of two overlapping time windows. """
        """ It uses a short window and a long window and compares the difference. """
        """ The long window has to be equal or shorther than the time window that """
        """ this function receives (usually equal), and the short window has to be """
        """ equal or shorter than the long window (usually shorter). """
        short_time_window = 10 # seconds
        long_time_window = 30 # seconds
        
        data_long = x['data'][0]
        data_short = data_long[len(data_long) - int(len(data_long)*(short_time_window/long_time_window)):]
        
        if len(data_short) > 0 and len(data_long) > 0:
            print("computing change in IBI")
            return _mean_ibi(data_short, self.primary_sampling_rate) / _mean_ibi(data_long, self.primary_sampling_rate)
        else:
            return 0


# Run the node from command line
if __name__ == '__main__':
    node = mu.midas_parse_config(ECGNode, sys.argv)
    if node:
        node.start()
        node.show_ui()
