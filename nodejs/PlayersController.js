'use strict'

const util = require('util')
const db = require('./db')
const uuidv1 = require('uuid/v1')

module.exports = {

    allplayerpokemon: (req, res) => {
        var promise = db.testPromise();
        var promise_2 = db.getdb();

        promise_2.then(function (e) {

            var t = e.db("demo").collection("PokemonPlayer").find({ playerId: req.params.id }).toArray(function (err, result) {
                console.log("--- Pokemon Player ---")
                console.log(req.params);
                console.log(result);
                res.json(result);
            });

        });
    },
    playerpokemon: (req, res) => {
        var promise = db.testPromise();
        var promise_2 = db.getdb();

        promise_2.then(function (e) {

            var t = e.db("demo").collection("PokemonPlayer").find({ playerId: req.body.playerId, pokemonId: req.body.pokemonId }).toArray(function (err, result) {
                console.log("--- Single Pokemon Player ---")
                console.dir(req.body);
                console.log(result);
                res.json(result);
            });

        });
    },
    insertpokemon: (req, res) => {
        var promise = db.testPromise();
        var promise_2 = db.getdb();

        promise_2.then(function (e) {

            const _uuid = require('uuid/v1')


            console.log("-- Insert --");
            console.log(req.body);
            console.log(req.params);
            console.log(req.query);

            var t = e.db("demo").collection("PokemonPlayer").insertOne({
                id: _uuid(),
                playerId: req.body.playerId,
                pokemonId: req.body.pokemonId,
                natureId: req.body.natureId,
                "iv_hp": req.body.iv_hp,
                "iv_attack": req.body.iv_attack,
                "iv_def": req.body.iv_def,
                "iv_spatk": req.body.iv_spatk,
                "iv_spdef": req.body.iv_spdef,
                "iv_speed": req.body.iv_speed,
                "shiny": req.body.shiny,
                "createDate": new Date()
            }, function (err, result) {
                res.json({ "message": "Thêm thành công !!!" });
            });
        });
    },
    updatepokemon: (req, res) => {
        var promise = db.testPromise();
        var promise_2 = db.getdb();

        promise_2.then(function (e) {

            console.log("-- Update --");
            console.log(req.body);
            console.log(req.params);
            console.log(req.query);

            var t = e.db("demo").collection("PokemonPlayer").update(
                { id: req.body.id },   // Query parameter
                {
                    id: req.body.id,
                    playerId: req.body.playerId,
                    pokemonId: req.body.pokemonId,
                    natureId: req.body.natureId,
                    iv_hp: req.body.iv_hp,
                    iv_attack: req.body.iv_attack,
                    iv_def: req.body.iv_def,
                    iv_spatk: req.body.iv_spatk,
                    iv_spdef: req.body.iv_spdef,
                    iv_speed: req.body.iv_speed,
                    shiny: req.body.shiny,
                    createDate: req.body.createDate
                },
                { upsert: true }    // Options
                , function (err, result) {
                res.json({ "message": "Sửa thành công !!!" });
            });
        });
    },
    deletepokemon: (req, res) => {
        var promise = db.testPromise();
        var promise_2 = db.getdb();

        promise_2.then(function (e) {

            console.log("-- Delete --");
            console.log(req.body);
            console.log(req.params);
            console.log(req.query);

            var t = e.db("demo").collection("PokemonPlayer").deleteOne(
                { id: req.params.id }, function (err, result) {
                res.json({ "message": "Xóa thành công !!!" });
            });
        });
    },
    getnature: (req, res) => {
        var promise = db.testPromise();
        var promise_2 = db.getdb();

        promise_2.then(function (e) {

            var t = e.db("demo").collection("Nature").find().toArray(function (err, result) {
                console.log("--- Nature ---")
                console.log(req.params);
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