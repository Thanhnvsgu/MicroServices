'use strict';
module.exports = function(app) {
  let usersCtrl = require('./UsersController');

  // todoList Routes
  app.route('/users')
    .get(usersCtrl.get)

//   app.route('/products/:productId')
//     .get(productsCtrl.detail)
//     .put(productsCtrl.update)
//     .delete(productsCtrl.delete);
};