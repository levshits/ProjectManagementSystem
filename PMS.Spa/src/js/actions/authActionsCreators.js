/**
 * Created by levsh on 12/13/2015.
 */
var PmsDispatcher = require('../dispatcher/PmsDispatcher');
var PmsConstants = require('../constants/PmsConstants');
var AuthService = require('../service/authService');

var ActionTypes = PmsConstants.ActionTypes;

module.exports = {
    login: function(username, password) {
        console.log(username, password);
        AuthService.login(username, password)
            .then(function(){
                PmsDispatcher.dispatch({
                    type: ActionTypes.LOGIN,
                    username: username,
                    password: password
                });
            });
    },
    logout: function(){
        PmsDispatcher.dispatch({
            type: ActionTypes.LOGOUT
        });
    }

};