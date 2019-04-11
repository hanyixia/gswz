window.onload=function(){
	//  1..导航条
	    $(document).on('click', ".nav>li", function () {
	        $(".nav>li").eq($(this).index()).addClass("active").siblings().removeClass("active");
	    })
    
}
