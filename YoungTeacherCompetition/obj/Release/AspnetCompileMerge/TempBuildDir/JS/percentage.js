// Canvas Percentage
var Percentage = function (obj) {
	var defaults = { //defaults params
		num: 0, //百分比值(0.01 or 0.5 ...)
		radius: 50, //圆的半径
		emptyWidth: 20, //未占用部分的边框宽度
		occupyWidth: 26, //占用部分的边框宽度
		emptyColor: '#e1e1e1', // 未占用部分的颜色
		occupyColor: '#24c46b', //占用部分的颜色
		fontColor: '#24c46b', //字体颜色
		fontStyle: 'bold 14px Microsoft YaHei' //字体样式
	}
	this.oCanvas = obj;
	try {
		this.setting = eval("(" + this.oCanvas.getAttribute('data-setting') + ")");
	} catch(e) {
		return;
	}
	this.options = this.extend({}, [defaults, this.setting], true);
	
	try {
		this.c = this.oCanvas.getContext('2d');
		this.init();
	} catch(e) {
		this.compatible();
	}

};

Percentage.prototype = {
	init: function () {
		var _this = this;
		if(this.options.occupyWidth < this.options.emptyWidth) this.options.occupyWidth = this.options.emptyWidth;
		this.oCanvas.width = this.oCanvas.height = this.options.radius*2 + this.options.occupyWidth;
		
		_this.draw(_this.c, 0);
		window.addEventListener('scroll', start, false);
		start();
		
		function start() {
			var scrollTop = document.documentElement.scrollTop || document.body.scrollTop;
			if(_this.offsetTop(_this.oCanvas) + _this.oCanvas.width/2 <= scrollTop + window.innerHeight) {
				for(var i = 0; i <= parseInt(_this.options.num*100); i++) {
					(function (i) {
						setTimeout(function () {
							_this.draw(_this.c, i/100);
						}, i*30);
					})(i);
				}
				window.removeEventListener('scroll', start);
			}
		}
		
	},
	draw: function (c,num) {
		var i = num ? 0.05 : 0;
		c.clearRect(0, 0, this.oCanvas.width, this.oCanvas.height);
		this.drawArc(c, this.options.emptyWidth, this.options.emptyColor, 0, 2*Math.PI);
		this.drawArc(c, this.options.emptyWidth, 'white', num*2*Math.PI-i, num*2*Math.PI*2+i);
		this.drawArc(c, this.options.occupyWidth, this.options.occupyColor, num*2*Math.PI, num*2*Math.PI*2);
		this.drawFont(c, Math.round(num*100)+'%', this.oCanvas.width/2, this.oCanvas.width/2);
	},
	drawArc: function (c, size, color, start, end) {
		c.lineWidth = size;
		c.strokeStyle = color;
		c.beginPath();
		c.arc(this.oCanvas.width/2, this.oCanvas.height/2, this.options.radius, start, end);
		c.stroke();
	},
	drawFont: function (c, text, start, end) {
		c.textAlign = 'center';
		c.textBaseline = 'middle';
		c.font = this.options.fontStyle;
		c.fillStyle = this.options.fontColor;
		c.fillText(text, start, end);
	},
	extend: function (des, src, override) { //merge json
		if(src instanceof Array) {
			for(var i = 0; i < src.length; i++) {
				this.extend(des, src[i], override);
			}
		} else {
			for(i in src) {
				if(override || !(i in des)) des[i] = src[i];
			}
		}
		return des;
	},
	compatible: function () {
		var oSpan = document.createElement('span'), oOccupy = document.createElement('span');
		var sPercentage = parseInt(this.options.num*100) + '%';
		
		with(oSpan.style) {
			position = 'relative';
			display = 'inline-block';
			verticalAlign = 'middle';
			width = this.options.radius*2 + this.options.occupyWidth + 'px';
			height = this.options.occupyWidth + 'px';
			marginTop = marginBottom =  this.options.radius + 'px';
			background = this.options.emptyColor;
		}
		with(oOccupy.style) {
			position = 'absolute';
			width = sPercentage;
			height = '100%';
			background = this.options.occupyColor;
			textIndent = '1em';
			font = 'bold 16px/'+ this.options.occupyWidth +'px Microsoft YaHei';
			left = 0;
			whiteSpace  = 'nowrap'
		}
		oOccupy.innerHTML = sPercentage;
		oSpan.appendChild(oOccupy);
		this.oCanvas.parentNode.insertBefore(oSpan, this.oCanvas);
	},
	offsetTop: function (obj) {
		var num = obj.offsetTop;
		var tempObj = obj.offsetParent;
		while(tempObj) {
			num += tempObj.offsetTop;
			tempObj = tempObj.offsetParent;	
		}
		return num;
	}
};

Percentage.init = function (objs) {
	if(!objs) return;
	if(objs.length) {
		for(var i = 0; i < objs.length; i++) {
			new this(objs[i]);
		}
	} else {
		new this(objs);
	}
};

window["Percentage"] = Percentage;



