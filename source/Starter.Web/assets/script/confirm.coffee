require(["jquery", "util", "dialog"], ($, util, dialog) ->
	$dialog = $("#confirm")
	$message = $dialog.find(".message")
	$yes = $dialog.find("a.yes")
	$no = $dialog.find("a.no")

	bind = (callback) ->
		$yes.click ->
			this.hide()
			callback()

		$no.click ->
			this.hide()

		$(document).keyup (e) ->
			if e.keyCode == 13 || e.keyCode == 27
				$(document).unbind("keyup")
				this.hide()
				
			if e.keyCode == 13
				callback()
		
	return {
		show: (callback, question, y, n) ->
			dialog.hide()

			$message.text(question) if question
			$yes.text(y) if y
			$no.text(y) if n

			util.centre $dialog
			$dialog.fadeIn 500

			bind callback
	}
)