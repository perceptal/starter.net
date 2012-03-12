define(["jquery", "util"], ($, util) ->
	
	determine_route = (link) ->
		link.removeClass "active"
      
		action = link.attr("class") or "index"
		controller = link.parent().attr("id") or link.parent().attr("class") or $("body").attr("data-controller")
		area = link.parent().attr("data-area") or link.parent().parent().attr("data-area") or controller
      
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

		retrieve $link.attr("href"), determine_route($link)

	return {
		init_click: (container, link) ->
			$(container).delegate(link, "click", on_click)
	}

)