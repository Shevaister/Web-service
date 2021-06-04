function login(showhide){
	if(showhide == "show"){
    	document.getElementById('popupbox').style.visibility="visible";
	}
	else if(showhide == "hide"){
    	document.getElementById('popupbox').style.visibility="hidden"; 
	}
}

$(document).ready(function(){
  $("a").on('click', function(event) {
    if (this.hash !== "") {
      event.preventDefault();
      var hash = this.hash;
      $('html, body').animate({
        scrollTop: $(hash).offset().top
      }, 750, function(){
        window.location.hash = hash;
      });
    }
  });
});

var smoothJumpUp = function() {
    if (document.body.scrollTop > 0 || document.documentElement.scrollTop > 0) {
        window.scrollBy(0,-9);
        setTimeout(smoothJumpUp, 1);
    }
}
    
window.onscroll = function() {
    var scrolled = window.pageYOffset || document.documentElement.scrollTop;
    if (scrolled > 150) {
	   	document.getElementById('upbutton').style.display = 'block';
    } 
    else {
    	document.getElementById('upbutton').style.display = 'none';
    }
}


 (function() {
      var inpElem = document.getElementById('input__file'),
          divElem = document.getElementById('preview');
      
      inpElem.addEventListener("change", function(e) {
          preview(this.files[0]);
      });
      
      function preview(file) {
        if ( file.type.match(/image.*/) ) {
          var reader = new FileReader(), img;
          
          reader.addEventListener("load", function(event) {
            img = document.createElement('img');
            img.src = event.target.result;
            divElem.appendChild(img);
          });
          
          reader.readAsDataURL(file);
        }
      }
    })();


