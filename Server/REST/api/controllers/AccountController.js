'use strict'

const util = require('util')
const mysql = require('mysql')
const db = require('./../db')

module.exports = {
    get: (req, res) => {
        let sql = 'SELECT * FROM users'
        db.query(sql, (err, response) => {
            if (err) throw err
            res.json(response)
        })
    },
    detail: (req, res) => {
        let sql = 'SELECT * FROM users WHERE Username = ?'
        db.query(sql, [req.params.Username], (err, response) => {     // db.query dc truyen vao lenh sql, "?" dc thay bang tham so trong ngoac vuong
            if (err) throw err
            res.json(response)
        })
    },
    update: (req, res) => {
        let data = req.body;
        let productId = req.params.productId;
        let sql = 'UPDATE account SET ? WHERE AccountID = ?'
        db.query(sql, [data, productId], (err, response) => {
            if (err) throw err
            res.json({message: 'Update success!'})
        })
    },
    store: (req, res) => {
        let data = req.body;
        let sql = 'INSERT INTO Users SET ?'
        db.query(sql, [data], (err, response) => {
            if (err.code=='ER_DUP_ENTRY') return res.status(500).send(err.code);
            res.json({message: 'Insert success!'})
        })
    },
    delete: (req, res) => {
        let sql = 'DELETE FROM Account WHERE AccountID = ?'
        db.query(sql, [req.params.AccountId], (err, response) => {
            if (err) throw err
            res.json({message: 'Delete success!'})
        })
    }
}