var express = require('express');
var app = express();

var mysql = require('mysql');
var port = process.env.PORT || 3000;

var con = mysql.createConnection({
    host: "192.168.68.4",
    user: "aquatan",
	password: "akahire",
	database: "aqualog",
	//table: "log"
});

//WHERE label LIKE 'target_15121%'

app.get('/', function (req, res) {
	con.connect(function(err) {
 	con.query("SELECT * FROM log WHERE label LIKE 'target_15%'ORDER BY timestamp DESC LIMIT 20", function (err, result, fields) {
    	if (err) throw err;
   		res.send(result);
   		//console.log(result);
 		});
	});
});

app.listen(port, function() {
	console.log('Starting node.js on port ' + port);
});
