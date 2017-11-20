var socket = io.connect({'forceNew':true});

socket.on('pos',function(x,y) {
	setPos(x,y);
});
function move(x,y) {
	socket.emit('pos',{'x':x,'y':y});
} 