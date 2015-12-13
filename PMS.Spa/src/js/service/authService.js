/**
 * Created by levsh on 12/13/2015.
 */
var axios = require('axios');
module.exports = {
    login: function(username, password){
        return axios.post(
            "/token",
            {
                username: username,
                password: password,
                grant_type: "password"
            },
            {
                headers: {'ContentType': 'application/x-www-form-urlencoded'}
            }
        )
    }
};