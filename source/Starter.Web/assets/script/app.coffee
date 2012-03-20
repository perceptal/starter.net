define(["require", "jquery", "menu", "page", "dialog", "controllers/controller"], (require, $, menu, page, dialog, controller) ->

	$content = $("#body")

	navigate = (e, data) ->
		page.set_route data.route
		page.set_address data.url
		page.set_navigation()
		page.display $(this), data.html
		controller.run data.route

	first_init = () ->
		$content.bind "navigate.page", navigate
		menu.init_click "ul", "a"
		page.set_navigation()
		dialog.bind()
		dialog.trigger()
		controller.run page.get_route()

	return {
		initialize: ->
			first_init()
	}
)