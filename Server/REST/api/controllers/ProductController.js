'use strict'

const util = require('util')
const mysql = require('mysql')
const db = require('./../db')

module.exports = {
    getByCategory: (req, res) => {
        let sql = 'SELECT * FROM product where Category = ?'
        db.query(sql, [req.params.Category], (err, response) => {
            if (err) throw err
            res.json(response)
        })
    },
    getAllProducts: (req, res) => {
        let sql = 'SELECT * FROM product'
        db.query(sql, (err, response) => {    
            if (err) throw err
            res.json(response)
        })
    },
    store: (req, res) => {
        let data = req.body;
        let sql = 'INSERT INTO product SET ?'
        db.query(sql, [data], (err, response) => {
            if (err.code=='ER_DUP_ENTRY') return res.status(500).send(err.code);
            res.json({message: 'Insert success!'})
        })
    }
}