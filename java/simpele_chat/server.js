"use strict";

const express = require("express");
const http = require("http");
const socketio = require("socket.io");
const bodyParser = require("body-parser");

const routes = require("./utils/routes");
const config = require("./utils/config");

//Server class
class Server {
  constructor() {
    this.port = process.env.PORT || 81;
    this.host = `localhost`;

    this.app = express();
    this.http = http.Server(this.app);
    this.socket = socketio(this.http);
  }

  /*Applicatie config*/
  appConfig() {
    this.app.use(bodyParser.json());
    new config(this.app);
  }

  /* Including app Routes starts*/
  includeRoutes() {
    new routes(this.app, this.socket).routesConfig();
  }
  /* Including app Routes ends*/

  //Applicatie uitvoeren  laad alle methodes
  appExecute() {
    this.appConfig();
    this.includeRoutes();

    //server luisterd naar  Port op host
    this.http.listen(this.port, this.host, () => {
      console.log(`Server luisterd naar http://${this.host}:${this.port}`);
    });
  }
}

//Server starten
const app = new Server();
app.appExecute();
