let express = require("express");
let app = express();
const bodyParser = require('body-parser')
require('dotenv').config();



let port = process.env.port || 4000;

app.use(bodyParser.urlencoded({ extended: true }))
app.use(bodyParser.json())

console.log("--------------------");
let routes = require('./routes') //importing route
routes(app)


app.use(function(req, res) {
    res.status(404).send({url: req.originalUrl + ' not found'})
})

app.listen(port);

console.log("RESTful api start on port " + port);