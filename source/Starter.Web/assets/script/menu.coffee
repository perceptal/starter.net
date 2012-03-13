define(["jquery", "util"], ($, util) ->
	
	get_route = ($link) ->
		action = $link.attr("class") or "index"
		controller = $link.parent().attr("id") or $link.parent().attr("class") or $("body").data("controller")
		area = $link.parent().data("area") or $link.parent().parent().data("area") or controller
      
		area: area.toLowerCase()
		controller: controller.toLowerCase()
		action: action.toLowerCase()

	retrieve = (url, route) ->
		$content = $("#body")
		
		util.spin()
		
		$.ajax(
			url: url,
			dataType: "html",
			type: "get"
		).success((data) ->
			$content.trigger "navigate.page", 
				html: data, 
				route: route,
				url: url
		).complete ->
			util.unspin()

	on_click = (e) ->
		e.preventDefault()
		e.stopPropagation()

		$link = $(this)
		$link.removeClass "active"
      
		retrieve $link.attr("href"), get_route($link)

	return {
		init_click: (container, link) ->
			$(container).delegate(link, "click", on_click)
	}

)