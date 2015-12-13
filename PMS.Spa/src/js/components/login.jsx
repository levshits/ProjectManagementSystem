var React = require('react');
var Bootstrap = require('react-bootstrap');
var AuthStore = require('../stores/authStore');
var AuthActionsCreators = require('../actions/authActionsCreators');

var Login = React.createClass({
    componentDidMount: function() {
        AuthStore.addChangeListener(this._onChange);
    },

    componentWillUnmount: function() {
        AuthStore.removeChangeListener(this._onChange);
    },
    _onChange: function(){
        this.setState({});
    },
    _onSubmit: function(e){
        console.log(e);
        e.preventDefault();
        AuthActionsCreators.login("123","156");
    },
    render: function(){
        return(
            <div>
                <h1>Login page</h1>
                <Bootstrap.Button onClick={this._onSubmit}>Login</Bootstrap.Button>
                <form onsubmit={this._onSubmit}>

                </form>
            </div>
        );
    }
});

module.exports = Login;