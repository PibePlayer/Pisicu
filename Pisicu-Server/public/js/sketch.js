var mx = 0;
var my = 0;

function Player(x,y){

	this.x = x;
	this.y = y;

	this.draw = function(){

		fill(200,0,0);
		ellipse(this.x,this.y,40);
	}
}

var p = new Player(300,300);

function setup() {
	createCanvas(800,600);	
}

function draw() {
		
	background(255);

	p.draw();

	if(mx != mouseX || my != mouseY){

		mx = mouseX;
		my = mouseY;

		move(mx,my);
	}

	fill(100,300,10);
	ellipse(mx,my,40);
}

function setPos(x,y){
	p.x = x;
	p.y = y;
}