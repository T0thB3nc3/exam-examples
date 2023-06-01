const connection = require('../config/db');

const tutorials = {
    getAll(req,res){
        let sql = 'select * from tutorials';
        connection.query(sql,(err,data)=>{
            if (err){
                res.status(500).send({
                    message: err.message || 'Unknow error'
                })
            }else {
                res.send(data); // adatküldés
            }
        });
    },
    create(req,res){
        const newTutorial = {
            title: req.body.title,
            description: req.body.description,
            published: req.body.published
        };
        const sql = 'insert into tutorials set ?';
        connection.query(sql,newTutorial,(err,data)=>{
            if (err){
                res.status(500).send({
                    message: err.message || 'Unknow error'
                })
            }else {
                res.send(
                    {
                        id: data.insertId,
                        ...newTutorial
                    }
                ); 
            }
        });
    }

}

module.exports = tutorials;