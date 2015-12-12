import React from 'react'
import ReactDOM from 'react-dom'
import { Router, Route, IndexRoute } from 'react-router'
import { createHistory, useBasename } from 'history'
import App from './components/app';
import Home from './components/home';
import Dashboard from './components/dashboard';

const history = useBasename(createHistory)({
    basename: '/'
});
const routes =
    <Route path="/" component={App}>
        <IndexRoute component={Home}/>
        <Route path="/home" component={Home}/>
        <Route path="/dashboard" component={Dashboard}/>
    </Route>;
ReactDOM.render(<Router history={history} routes={routes}/>, document.getElementById('app'));