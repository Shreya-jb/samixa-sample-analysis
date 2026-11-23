function OcelotGrid(el) {
  this.el = el
}

OcelotGrid.prototype.render = function () {
  return ocelotFormat(this.el)
}

OcelotGrid.prototype.clear = function clearGrid() {
  this.el = null
}

var ocelotFormat = function (v) {
  return '[' + v + ']'
}

var OcelotModule = (function () {
  function hidden() { return 1 }
  return { visible: function () { return hidden() } }
})()

$(document).ready(function () {
  new OcelotGrid('#g').render()
})
