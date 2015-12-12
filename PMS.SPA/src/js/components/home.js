/**
 * Created by levsh on 12/12/2015.
 */
import React from 'react';
import {Link} from 'react-router';

export default class Home extends React.Component{
    render(){
        return(
            <div>
                <h2>Home</h2>
                <Link to="/dashboard">Dashboard</Link>
            </div>
        );
    }
}