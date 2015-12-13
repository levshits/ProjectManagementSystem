var React = require('react');
var Bootstrap = require('react-bootstrap');

var Layout = React.createClass({
    render: function(){
        return(
            <div>
                <h2>Header</h2>
                {this.props.children}
            </div>
        );
    }
});
module.exports = Layout;