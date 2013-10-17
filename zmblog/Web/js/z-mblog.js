$(function(){
	initEvent();
});



function initEvent(){
	 $(".youinput").keyup(function(e){

        var val=$(".youinput").val();
       
        if (e.keyCode==8&&val=="") {

           $(".youinput").css("background-image",'url("css/images/4.bmp")');
        }
        else{$(".youinput").css("background-image","none");};
        
    });



	 $(".youinput2").keyup(function(e){

        var val=$(".youinput2").val();
       
        if (e.keyCode==8&&val=="") {

           $(".youinput2").css("background-image",'url("css/images/5.bmp")');
        }
        else{$(".youinput2").css("background-image","none");};
        
    });



}