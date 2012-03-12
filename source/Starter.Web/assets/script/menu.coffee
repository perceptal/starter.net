define(["jquery", "util"], ($, util) ->
	
	determine_route = (link) ->
		link.removeClass "active"
      
		action = link.attr("class") or "index"
		controller = link.parent().attr("id") or link.parent().attr("class") or $("body").attr("data-controller")
		area = link.parent().attr("data-area") or link.parent().parent().attr("data-area") or controller
		action = action.substr(0, action.indexOf(",")) if action.indexOf(",") >= 0
      
		controller = controller.substr(0, controller.indexOf(","))  if controller.indexOf(",") >= 0
      
		area: area.toLowerCase()
		controller: controller.toLowerCase()
		action: action.toLowerCase()

	navigate = (url, route) ->
		$content = $("#body")

		util.spin()

		$.ajax(
			url: url,
			dataType: "html",
			type: "get"
		).success((data) ->
			display $content, data, route
		).complete ->
			util.unspin()

	display = ($content, data, route) ->
		$content.html data

	on_click = (e) ->
		e.preventDefault()
		e.stopPropagation()

		$link = $(this)

		navigate $link.attr("href"), determine_route($link)

	return {
		click: (container, link) ->
			$(container).delegate(link, "click", on_click)
	}

)