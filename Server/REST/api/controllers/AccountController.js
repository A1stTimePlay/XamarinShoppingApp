'use strict'

const util = require('util')
const mysql = require('mysql')
const db = require('./../db')

module.exports = {
    getAllUsers: (req, res) => {
        let sql = 'SELECT * FROM users'
        db.query(sql, (err, response) => {
            if (err) throw err
            res.json(response)
        })
    },
    getUserByName: (req, res) => {
        let sql = 'SELECT * FROM users WHERE Username = ?'
        db.query(sql, [req.params.Username], (err, response) => {     // db.query dc truyen vao lenh sql, "?" dc thay bang tham so trong ngoac vuong
            if (err) throw err
            res.json(response)
        })
    },
    getByEmail: (req, res) => {
        let sql = 'SELECT * FROM Users WHERE Email = ?'
        db.query(sql, [req.params.Email], (err, response) => {
            if (err) throw err
            res.json(response)
        })
    },
    update: (req, res) => {
        let data = req.body;
        let userName = req.params.Username;
        let sql = 'UPDATE users SET ? WHERE Username = ?'
        db.query(sql, [data, userName], (err, response) => {
            if (err) throw err
            res.json({message: 'Update success!'})
        })
    },
    store: (req, res) => {
        let data = req.body;
        let sql = 'INSERT INTO Users SET ?'
        db.query(sql, [data], (err, response) => {
            if (err) return res.status(500).send(err.code);
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