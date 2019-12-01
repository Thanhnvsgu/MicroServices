'use strict'

const mongodb = require("mongodb").MongoClient;

let dbport = process.env.NODEJSSERVER_DB_PORT;
let dbhost = process.env.NODEJSSERVER_DB_HOST;

const url = `mongodb://root:P%40ssw0rd@${dbhost == null ? 'localhost' : dbhost}:${dbport == null ? '27017' : dbport}/`;



function getdb(){

    var promise = new Promise(function(resolve,reject){
        mongodb.connect(url, function(err, db) {
            if (err) {
                console.log(err);
                reject(err);
                throw err;
            }
            var dbo = db.db("demo");
            // var query = { address: "Park Lane 38" };
    
            console.log("------- Test Db ---------");
            console.log(dbo);

            // console.log(dbo);
        
            resolve(dbo);
        
            // dbo.collection("user").find().toArray(function(err, result) {
            //   if (err) throw err;
            //   console.log(result);
            //   db.close();    
            // });
        });
    });
    console.time("--time promise--");

    console.log(promise);

    return promise;



    // promise.then( e => function(e){
    //     console.log("--- Promise Done !!! ---");
    //     console.log(e);
    // });

    // var db;

    // console.log("--------0o0-------")
    // console.log(db);

    // return db;
}



async function getdata(){
    var res = await getdb().then(e => function(e){
        return e;
    });
    console.log("-------- Get Data -------")
    console.time("--time promise--");
    console.log(res);
}

// getdata();


module.exports = {
    getdb: function getdb(){

        console.log("---begin---");
        return new Promise(function(resolve,reject){
            mongodb.connect(url, function(err, db) {
                if (err) {
                    console.log(err);
                    reject(err);
                    throw err;
                }
                var dbo = db.db("demo");
                // var query = { address: "Park Lane 38" };
        
                // console.log("------- Test Db ---------");
                // console.log(dbo);

                // console.log(dbo);

                dbo.collection("user").find({}).toArray(function(err, result){
                    console.log(result);
                });

                console.log("--return db--");
                resolve(db);
            
                // dbo.collection("user").find().toArray(function(err, result) {
                //   if (err) throw err;
                //   console.log(result);
                //   db.close();    
                // });
            });
        });
    
    
    
        // promise.then( e => function(e){
        //     console.log("--- Promise Done !!! ---");
        //     console.log(e);
        // });
    
        // var db;
    
        // console.log("--------0o0-------")
        // console.log(db);
    
        // return db;
    },
    testPromise: function t(){
        return new Promise(function(resolve,reject){
            resolve({id:1,name:"thanhetn"});
        });
    }
};


// module.exports = {

//     connectToServer: function( callback ) {
//       MongoClient.connect( url,  { useNewUrlParser: true }, function( err, client ) {
//         _db  = client.db('test_db');
//         return callback( err );
//       } );
//     },
  
//     getDb: function() {
//       return _db;
//     }
//   };