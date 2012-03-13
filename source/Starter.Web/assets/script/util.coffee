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

		centre: ($element) ->
			$element.css
				top: ($(window).scrollTop() + 175) + "px", 
				left: "50%", margin:"-" + ($element.height() / 2) + "px 0 0 -" + ($element.width() / 2) + "px"

	}
)