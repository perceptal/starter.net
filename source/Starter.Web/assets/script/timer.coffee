define([], () ->
	timer = null

	return {
		cancel: ->
			if timer
				window.clearTimeout timer
				timer = null;

		delay: (timeout, callback) ->
			this.cancel()
		
			timer = window.setTimeout(->
				timer = null
				callback()
			, timeout)
	}
)