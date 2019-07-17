console.log("I am alive");

const SerialPort = require('serialport')
const Readline = require('@serialport/parser-readline')

const { Client } = require('node-osc')
const client = new Client('127.0.0.1', 3333)


var port = new SerialPort('/dev/cu.usbmodem14101', {
    baudRate: 9600,
});

const parser = port.pipe(new Readline({ delimiter: '\r\n' }))
parser.on('data', function(data) {
    console.log(data)
    client.send('/oscAddress', parseInt(data))
});