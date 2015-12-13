var React = require('react');
var {Form, Input, Button} = require('react-bootstrap');
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
            <header className="header">
                <div className="text-vertical-center">
                    <h1>PMS</h1>
                    <h3>Project management system</h3>
                    <form className="form-horizontal">
                        <Input type="text" label="Login" labelClassName="col-xs-2" wrapperClassName="col-xs-10" />
                        <Input type="password" label="Password" labelClassName="col-xs-2" wrapperClassName="col-xs-10" />
                    </form>
                </div>
            </header>
        );
    }
});

module.exports = Login;