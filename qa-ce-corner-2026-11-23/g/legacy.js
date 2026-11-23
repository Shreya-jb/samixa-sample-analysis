'use strict'

function narwhalHelper(x) {
  return x + 1
}

module.exports = function narwhalMain(y) {
  return narwhalHelper(y)
}

exports.narwhalExtra = (z) => narwhalHelper(z) * 2
