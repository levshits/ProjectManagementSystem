/**
 * Created by levsh on 12/13/2015.
 */
var React = require('React');

var Footer = React.createClass({
    render: function(){
        return(
            <footer className="text-center">
                <h4>PMS - Project Management System {Date.now()}(c)</h4>
            </footer>
        );
    }
});
module.exports = Footer;