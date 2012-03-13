define(["jquery", "timer"], ($, timer) ->
	
	$dialog = $("#dialog")
	$message = $dialog.find(".message")
	$close = $dialog.find("a.close")

	position = () ->
		$dialog.css
			top:($(window).scrollTop() + 175) + "px", 
			left:"50%", margin:"-" + ($dialog.height() / 2) + "px 0 0 -" + ($dialog.width() / 2) + "px"

	is_loading = () ->
		$message.hasClass "loading" and $message.text.length > 0

	return {
		set: (text, classifier) ->
			$message.attr "class", "message"
			$message.addClass classifier
			$message.text text

			this.trigger

		clear: ->
			this.set ""
			
		show: ->
			if $message.text.length > 0
				position()			
				$dialog.fadeIn 500

				timer.delay(10000, () -> $dialog.hide()) if !is_loading()

			else
				$dialog.hide()

		hide: ->
			timer.cancel()
			$dialog.hide()

		bind: ->
			$dialog.bind "change.dialog", this.show
			$close.click this.hide

		trigger: ->
			$dialog.trigger "change.dialog"
	}
)