'use strict'

const util = require('util')
const db = require('./db')

module.exports = {
    get: (req, res) => {

        var promise = db.testPromise();
        var promise_2 = db.getdb();

        promise_2.then(function(e){
            var t = e.db("demo").collection("user").find().toArray(function(err, result){
                console.log(result);
                res.json(result);
            });
        });
    }

    // ,
    // detail: (req, res) => {
    //     let sql = 'SELECT * FROM products WHERE id = ?'
    //     db.query(sql, [req.params.productId], (err, response) => {
    //         if (err) throw err
    //         res.json(response[0])
    //     })
    // },
    // update: (req, res) => {
    //     let data = req.body;
    //     let productId = req.params.productId;
    //     let sql = 'UPDATE products SET ? WHERE id = ?'
    //     db.query(sql, [data, productId], (err, response) => {
    //         if (err) throw err
    //         res.json({message: 'Update success!'})
    //     })
    // },
    // store: (req, res) => {
    //     let data = req.body;
    //     let sql = 'INSERT INTO products SET ?'
    //     db.query(sql, [data], (err, response) => {
    //         if (err) throw err
    //         res.json({message: 'Insert success!'})
    //     })
    // },
    // delete: (req, res) => {
    //     let sql = 'DELETE FROM products WHERE id = ?'
    //     db.query(sql, [req.params.productId], (err, response) => {
    //         if (err) throw err
    //         res.json({message: 'Delete success!'})
    //     })
    // }
}