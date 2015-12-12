/**
 * Created by levsh on 12/12/2015.
 */
import React from 'react';

export default class App extends React.Component{
    render(){
        return(
          <div>
              <h1>App</h1>
              {this.props.children}
          </div>
        );
    }
}