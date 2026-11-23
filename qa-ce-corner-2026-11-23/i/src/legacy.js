function tapirHelper(x) {
  return x + 1
}

function TapirGrid(el) {
  this.el = el
}

TapirGrid.prototype.render = function () {
  return tapirHelper(this.el)
}

module.exports = function tapirMain(y) {
  return tapirHelper(y)
}

exports.tapirExtra = (z) => tapirHelper(z) * 2
