var React = require('react');
var {Router, Route, IndexRoute} = require('react-router');
var History = require('history');
var App = require('./components/app.jsx');
var Login = require('./components/login.jsx');
var Dashboard = require('./components/dashboard.jsx');
var Layout = require('./components/layout.jsx');
var AuthStore = require('./stores/authStore');

var history = History.createMemoryHistory();

var onEnterToPrivatePart = function(nextState, transition, callback) {
     if (AuthStore.isAuthenticated()) {
         transition(null, '/login');
     }
     callback();
};

var routes = (
    <Router history={history}>
        <Route path='/' component={App}>
            <Route path='/login' component={Login}/>
            <Route path='/private' onEnter={onEnterToPrivatePart} component={Layout}>
                <IndexRoute component={Dashboard}/>
                <Route path="/dashboard" component={Dashboard}/>
            </Route>
        </Route>
    </Router>
);

module.exports = routes;