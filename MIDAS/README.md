# Run commands

* Start streaming ECG from Bitalino:
`python streamBitalinoECG1.py`

* If there is a second Bitalino:
`python streamBitalinoECG2.py`

* Start MIDAS ECG node:
 `python3 ecg_node.py config.ini ecg1`
 
* If there is a second Bitalino:
`python3 ecg_node.py config.ini ecg2`

* Start MIDAS dispatcher:
`midas-dispatcher config.ini dispatcher`
