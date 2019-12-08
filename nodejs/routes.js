'use strict';
module.exports = function(app) {
  let usersCtrl = require('./UsersController');

  // todoList Routes
  app.route('/allplayer')
    .get(usersCtrl.get)

  app.route('/allplayerpokemon/:id').get(usersCtrl.allplayerpkm);

  app.route('/insertpokemon').post(usersCtrl.insertpokemon);

//   app.route('/products/:productId')
//     .get(productsCtrl.detail)
//     .put(productsCtrl.update)
//     .delete(productsCtrl.delete);
};