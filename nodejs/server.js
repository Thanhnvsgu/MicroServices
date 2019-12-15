let express = require("express");
var cors = require('cors');
let app = express();
const bodyParser = require('body-parser')
require('dotenv').config();



let port = process.env.port || 4000;

var corsOptions = {
    origin: '*',
    optionsSuccessStatus: 200 // some legacy browsers (IE11, various SmartTVs) choke on 204
}

app.use(bodyParser.urlencoded({ extended: true }))
app.use(bodyParser.json())
app.use(cors(corsOptions))



console.log("--------------------");
let routes = require('./routes') //importing route
routes(app)


app.use(function(req, res) {
    res.status(404).send({url: req.originalUrl + ' not found'})
})

app.listen(port);

console.log("RESTful api start on port " + port);