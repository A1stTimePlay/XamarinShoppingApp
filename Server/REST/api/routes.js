'use strict';
module.exports = function(app) {
  let accountCtrl = require('./controllers/AccountController');
  let productCtrl = require('./controllers/ProductController');
  let orderCtrl = require('./controllers/OrderController');
  let orderDetailCtrl = require('./controllers/OrderDetailController');

  app.route('/Users')
    .get(accountCtrl.getAllUsers)
    .post(accountCtrl.store);

  app.route('/User/Email/:Email')
    .get(accountCtrl.getByEmail)

  app.route('/User/:Username')
    .get(accountCtrl.getUserByName)
    .put(accountCtrl.update)
    .delete(accountCtrl.delete);
  
  app.route('/Products/:Category')
    .get(productCtrl.getByCategory)

  app.route('/Products')
    .get(productCtrl.getAllProducts)
    .post(accountCtrl.store);

  app.route('/Order')
    .get(orderCtrl.getOrderByIdUserAndOrderDate)
	.get(orderCtrl.getOrderByIdUser)
    .post(orderCtrl.store)
	
  app.route('/Order/:Id')
    .put(orderCtrl.update)
	
  app.route('/OrderDetail')
	.get(orderDetailCtrl.getOrderDetailByOrderId)
    .post(orderDetailCtrl.store)
};