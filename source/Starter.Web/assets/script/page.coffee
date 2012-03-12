define(["jquery", "util"], ($, util) ->

	$body = $("body")

	return {
		display: ($content, data) ->
			$content.html data

		set_route: (route) ->
			$body
				.attr("class", route.area)
				.attr("data-controller", route.controller)
				.attr("data-action", route.action);

		set_address: (url) ->
			window.history.pushState(null, "Blah", url) if util.supports_history()
	}
)
