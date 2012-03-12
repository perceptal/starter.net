﻿define(["jquery", "menu", "page"], ($, menu, page) ->

	$content = $("#body")

	navigate = (e, data) ->
		page.display $(this), data.html
		page.set_route data.route
		page.set_address data.url

	init = () ->
		menu.init_click "nav", "a"
		$content.bind "navigate.page", navigate

	return {
		initialize: ->
			init()
	}
)