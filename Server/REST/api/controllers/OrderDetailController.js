'use strict'

const util = require('util')
const mysql = require('mysql')
const db = require('./../db')

module.exports = {
    store: (req, res) => {
        let data = req.body;
        let sql = 'INSERT INTO orders_detail SET ?'
        db.query(sql, [data], (err, response) => {
            if (err) return res.status(500).send(err.code);
            res.json({message: 'Insert success!'})
        })
    },
    getOrderDetailByOrderId: (req, res) => {
        let sql = 'SELECT * FROM Orders_Detail WHERE id_order=?'
        db.query(sql, [req.query.id_order], (err, response) => {     // db.query dc truyen vao lenh sql, "?" dc thay bang tham so trong ngoac vuong
            if (err) throw err
            res.json(response)
        })
    }
}