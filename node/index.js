console.log("I am alive");

const SerialPort = require('serialport')
const Readline = require('@serialport/parser-readline')

const { Client } = require('node-osc')
const client = new Client('127.0.0.1', 3333)


var port = new SerialPort('/dev/cu.usbmodem14101', {
    baudRate: 9600,
});

port.on("error", function (error) {
    console.log("An error occurred: ", error.message);
});

const parser = port.pipe(new Readline({ delimiter: '\r\n' }))
parser.on('data', function(data) {
    if (data  != '0') {
        console.log(data)
        client.send('/oscAddress', data)
    }
});


setInterval(function(){
    client.send('/data', 'data');
    console.log("sent test");
}, 2000);