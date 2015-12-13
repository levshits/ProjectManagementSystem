var React = require('react');
var Bootstrap = require('react-bootstrap');
var Header = require('./header.jsx');
var Footer = require('./footer.jsx');

var Layout = React.createClass({
    render: function(){
        return(
            <div>
                <Header/>
                {this.props.children}
                <Footer/>
            </div>
        );
    }
});
module.exports = Layout;