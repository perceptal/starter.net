define(["jquery", "timer", "util"], ($, timer, util) ->
	
	$content = $("#body")
	$dialog = $("#dialog")
	$message = $dialog.find(".message")
	$close = $dialog.find("a.close")

	is_loading_dialog = () ->
		$message.hasClass "loading" and $message.text().length > 0

	return {
		set: (text, classifier) ->
			$message.attr "class", "message"
			$message.addClass classifier
			$message.text text

			this.trigger()

		clear: ->
			this.set ""
			
		show: ->
			if $message.text().length > 0
				util.centre $dialog		
				$dialog.fadeIn 500

				timer.delay(10000, () -> $dialog.hide()) if !is_loading_dialog()

			else
				$dialog.hide()

		hide: ->
			timer.cancel()
			$dialog.hide()

		bind: ->
			$dialog.bind "change.dialog", this.show
			$close.click this.hide
			$content.bind "navigate.page", this.hide

		trigger: ->
			$dialog.trigger "change.dialog"
	}
)