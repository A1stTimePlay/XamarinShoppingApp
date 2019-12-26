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
    }
}