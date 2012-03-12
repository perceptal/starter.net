define(["jquery"], ($) ->
	
	return {
		spin: ->
			$("nav li.loading").fadeIn 200
			$("body").css
				cursor: "wait"

		unspin: ->
			$("nav li.loading").fadeOut 200
			$("body").css
				cursor: "default"

		supports_history: ->
			!!(window.history and window.history.pushState)
	}
)