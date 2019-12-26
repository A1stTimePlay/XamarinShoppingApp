'use strict'

const util = require('util')
const mysql = require('mysql')
const db = require('./../db')

module.exports = {
    getOrderByIdUserAndOrderDate: (req, res) => {
        let sql = 'SELECT * FROM Orders WHERE id_user=? and order_date=?'
        db.query(sql, [req.query.id_user, req.query.order_date], (err, response) => {     // db.query dc truyen vao lenh sql, "?" dc thay bang tham so trong ngoac vuong
            if (err) throw err
            res.json(response)
        })
    },
    getOrderByIdUser: (req, res) => {
        let sql = 'SELECT * FROM Orders WHERE id_user=?'
        db.query(sql, [req.query.id_user], (err, response) => {     // db.query dc truyen vao lenh sql, "?" dc thay bang tham so trong ngoac vuong
            if (err) throw err
            res.json(response)
        })
    },
    store: (req, res) => {
        let data = req.body;
        let sql = 'INSERT INTO Orders SET ?'
        db.query(sql, [data], (err, response) => {
            if (err) throw err
            res.json({message: 'Insert success!'})
        })
    },
    delete: (req, res) => {
        let sql = 'DELETE FROM Users WHERE Username = ?'
        db.query(sql, [req.params.Username], (err, response) => {
            if (err) throw err
            res.json({message: 'Delete success!'})
        })
    }
}