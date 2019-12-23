'use strict';
module.exports = function(app) {
    let accountCtrl = require('./controllers/AccountController');
    let productCtrl = require('./controllers/ProductController');
    app.route('/Users')
        .get(accountCtrl.get)
        .post(accountCtrl.store);

    app.route('/User/:Username')
        .get(accountCtrl.detail)
        .put(accountCtrl.update)
        .delete(accountCtrl.delete);

    app.route('/Product/:Category')
        .get(productCtrl.detail)

};