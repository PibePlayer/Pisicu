var express = require('express');
var app = express();
var server = require('http').Server(app);
var io = require('socket.io')(server);
var mysql = require('mysql');
var fs = require('fs');

var f = new Date();
cad = f.getHours() + ":" + f.getMinutes() + ":" + f.getSeconds(); 

/************************************************************************/

var Activities = [{
    "name": "test",
    "pass": "123",
    "questions": [{
        "q": "Cuál es el mejor nombre?",
        "op0": "Humberto Canabrio",
        "op1": "José Antonio",
        "op2": "Gregorio Antonia",
        "op3": "Mirtha Legrand"
    }]
}]

var users = JSON.parse(fs.readFileSync("users.json", "utf8"));

/*
users.push({
	'name':"asd",
	'pass':"123"
});

console.log(JSON.stringify(users));

*/

function updatedb() {

	fs.writeFile("users.json", JSON.stringify(users), function(err) {
	    if(err) {
	        return console.log(err);
	    }
	});
}

/************************************************************************/

var conn = mysql.createConnection({

  host: "localhost",
  user: "root",
  password: "",
  database: "pisicu"
});

app.use(express.static('public'));

io.on('connection',function(socket) {

	console.log("Se conecto un usuario " + socket.id);

	var question = [{
		q:"Aprobaran la prueba",
		op1:"No",
		op2:"Si",
		op3:"Capaz",
		op4:"En diciembre"
	},
	{
		q:"Probando Pisicu",
		op1:"Si me gusta",
		op2:"No me gusto",
		op3:"Quizas, tengo que probarlo un poco más",
		op4:"Si, pero esta incompleto"
	},
	{
		q:"2Aprobaran la prueba",
		op1:"No",
		op2:"Si",
		op3:"Capaz",
		op4:"En diciembre"
	}]

	socket.on('login',function (username, pass) {

		console.log("login");
		console.log(username);
		console.log(pass);

		//check if user exists

		if(users.find(function (user){
		  return user.name == username && user.pass == pass;
		}) != undefined){
			socket.emit('profile', {"name": username})
			socket.emit('logged', true);

  socket.on('join', function(name, pass){
    if(Activities.find(function(activity){
      activity.name == name && activity.pass == pass}))
  });

		}

		/*socket.emit('text',question[0]);
		socket.on('next',function(data){
			if(data >= 3){
				socket.emit('finish');	
			}else{
				socket.emit('text',question[data]);
			}
		});*/
	});

	socket.on('register',function (username, pass) {

		console.log("register");
		console.log(username);
		console.log(pass);

		//register user 

		if(users.find(function (user){
		  return user.name == username;
		}) == undefined){
			users.push({"name": username, "pass": pass});
			updatedb();
			socket.emit('success', true);
		}
	});
});

server.listen(8081,function() {
	console.log("La magia ocurre en 8081 "  +  cad);
});

function query(conn) {

	conn.connect(function(err) {
	  if (err) throw err;
	  conn.query("SELECT * FROM users", function (err, result, fields) {
	    if (err) console.log(err);
	    console.log(result);
	  });
	});
}

function insert(conn,name,pass){

	conn.connect(function(err) {
		if (err) throw err;
		conn.query("INSERT INTO users (name,pass) VALUES ('" + name + "','" + pass + "')",function(err,result) {
			if (err) throw err;
			console.log("se incerto un dato");
		});
	});
}