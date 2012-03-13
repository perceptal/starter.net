define(["require", "./home", "./organisations", "./users"], (require) -> 
	return {
		run: (route) ->
			module = require("./" + route.controller)
			module.init() if module
			module[route.action] if module and module[route.action]		
	}
)