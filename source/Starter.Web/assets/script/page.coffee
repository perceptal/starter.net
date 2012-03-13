define(["jquery", "util"], ($, util) ->

	$body = $("body")

	return {
		display: ($content, data) ->
			$content.html data

		get_route: ->
			area: $body.attr "class"
			controller: $body.data "controller"
			action: $body.data "action"

		set_route: (route) ->
			$body
				.attr("class", route.area)
				.data("controller", route.controller)
				.data("action", route.action)

		set_navigation: (route) ->
			route = this.get_route() if !route
			
			$("nav:not('#security') ul").attr "class", route.area		
			$("nav:not('#security') ul").data "area", route.area		

			$("nav#security ul").attr "class", route.controller
			
		set_address: (url) ->
			window.history.pushState(null, "Foo", url) if util.supports_history()
	}
)
