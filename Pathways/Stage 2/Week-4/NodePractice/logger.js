const EventEmitter = require('events');
let url = "http://mylogger.io/log"

class Logger extends EventEmitter{
    log(message){
        console.log(message)

        //Raise an event
        this.emit('messageLogged', { id: 1, url: 'http://'});
    }
}

module.exports = Logger;