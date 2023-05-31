module.exports = (app) =>{
    const router = require('express').Router(); // router tárolja a útvonalakat
    const tutorials = require('../controllers/tutorial.controller');


    router.get('/',tutorials.getAll);
    router.post('/',tutorials.create);

    

    app.use('/api/tutorials',router); // default route név
}