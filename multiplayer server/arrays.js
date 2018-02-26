var express = require('express');
var app = express();

var server = require('http').createServer(app);
var io = require('socket.io').listen(server);

app.set('port', process.env.PORT || 3000);
var clients=[];

io.on("connection",function(socket){

	var currentUSer;

	socket.on("USER_CONNECT", function(){
		console.log("User connected");
		for (var i=0;i<clients.length;i++){
		socket.emit("USER_CONNECTED", { name:clients[i].name,position:clients[i].position})

		console.log("User name"+clients[i].name + "is connected");
		}
	});

	socket.on("PLAY", function( data){
		console.log(data);
		currentUSer={
			name:data.name,
			position:data.position
		}

		clients.push(currentUSer);
		socket.emit("PLAY", currentUSer);
		socket.broadcast.emit("USER_CONNECTED", currentUSer);

	});

	socket.on("MOVE",function(data){
		currentUSer.position=data.position;
		socket.emit("MOVE",currentUSer);
		socket.broadcast.emit("MOVE", currentUSer);
		console.log(currentUSer.name + "move to"+currentUSer.position);

	});

	socket.on("disconnect", function(){
 		socket.broadcast.emit("USER_DiSCIBBECTED", currentUSer);
 		for (var i = 0; i < clients.length; i++) {

 			if(clients[i].name===currentUSer.name){
 				console.log("User "+clients[i].name+"disconnected");
 				clients.splice(i,1);
 			}

 		};

	});

});

server.listen(app.get('port'), function(){
console.log("Server is running")
});