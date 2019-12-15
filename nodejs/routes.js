'use strict';
module.exports = function (app) {
  let ctrl = require('./PlayersController');

  // todoList Routes

  // Danh sach player pokemon
  app.route('/api/v1/allplayerpokemon/:id').get(ctrl.allplayerpokemon);
  //
  app.route('/api/v1/playerpokemon').post(ctrl.playerpokemon);
  // Them player pokemon
  app.route('/api/v1/insertplayerpokemon').post(ctrl.insertpokemon);
  // update player pokemon
  app.route('/api/v1/updateplayerpokemon').post(ctrl.updatepokemon);
  // delete playerp pokemon
  app.route('/api/v1/deleteplayerpokemon/:id').delete(ctrl.deletepokemon);
  // Danh sach nature 
  app.route('/api/v1/nature').get(ctrl.getnature);
  //   app.route('/products/:productId')
  //     .get(productsCtrl.detail)
  //     .put(productsCtrl.update)
  //     .delete(productsCtrl.delete);
};