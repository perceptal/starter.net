define(["jquery"], ($) ->

  initialize: ->
    alert $("body").data("controller")
)