var React = require('react');
var Link = require('react-router').Link;

var App = React.createClass({
    render: function(){
        return (
            <div>
                <h1>Hello world</h1>
                <Link to="/dashboard">Dashboard</Link>
                <Link to="/login">Login</Link>
                {this.props.children}
            </div>
        );
    }
});

module.exports = App;