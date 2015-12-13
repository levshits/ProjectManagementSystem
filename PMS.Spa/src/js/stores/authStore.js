/**
 * Created by levsh on 12/13/2015.
 */
var PmsDispatcher = require('../dispatcher/PmsDispatcher');
var PmsConstants = require('../constants/PmsConstants');
var EventEmitter = require('events').EventEmitter;
var assign = require('object-assign');

var ActionTypes = PmsConstants.ActionTypes;
var CHANGE_EVENT = 'change';

var authToken = null;
var userModel = {};

var AuthStore = assign({}, EventEmitter.prototype, {
    emitChange: function() {
        this.emit(CHANGE_EVENT);
    },
    addChangeListener: function(callback) {
        this.on(CHANGE_EVENT, callback);
    },
    removeChangeListener: function(callback) {
        this.removeListener(CHANGE_EVENT, callback);
    },
    isAuthenticated: function(){
        return authToken!=null;
    },
    getUser: function(){
        return userModel;
    }
});

AuthStore.dispatchToken = PmsDispatcher.register(function(action) {

    switch(action.type) {
        case ActionTypes.LOGIN:
            userModel =
            AuthStore.emitChange();
            break;

        case ActionTypes.LOGOUT:
            authToken = null;
            userModel = {};
            AuthStore.emitChange();
            break;
        default:
            //do nothing
    }

});

module.exports = AuthStore;