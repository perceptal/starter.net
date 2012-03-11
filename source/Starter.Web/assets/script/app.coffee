define(["jquery", "menu"], ($, menu) ->

	return {
		initialize: ->
			menu.click "nav a"
	}
)