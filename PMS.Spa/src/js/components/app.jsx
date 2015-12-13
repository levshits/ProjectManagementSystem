var React = require('react');
var Link = require('react-router').Link;

var App = React.createClass({
    render: function(){
        return (
            <div className="header">
                {this.props.children}
            </div>
        );
    }
});

module.exports = App;