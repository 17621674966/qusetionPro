layui.config({
	base : "/js/"
}).use(['form','element','layer','jquery'],function(){
	var form = layui.form,
		layer = parent.layer === undefined ? layui.layer : parent.layer,
		element = layui.element,
		$ = layui.jquery;
	$(".panel a").on("click",function(){
		window.parent.addTab($(this));
	})
	//用户数
    $.getJSON("/UserHome/GetHomeCount",
        function (res) {
			if (res.code = 200) {
				var data = res.data;
				$(".information span").text(data[0].informationCount);
				$(".company span").text(data[0].companyCount);
				$(".userAll span").text(data[0].userCount);
				$(".needs span").text(data[0].needsCount);
				$(".needs1 span").text(data[0].needsCount1);
            }
		}
	)
	//数字格式化
	$(".panel span").each(function(){
		$(this).html($(this).text()>9999 ? ($(this).text()/10000).toFixed(2) + "<em>万</em>" : $(this).text());	
	})

	

})
