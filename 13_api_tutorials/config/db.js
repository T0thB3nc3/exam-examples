const mysql = require('mysql');

const connection = mysql.createPool({
    host: '127.0.0.1',
    user: 'root',
    password: '',
    database: '14f_tutorials_db'
});

module.exports = connection;
