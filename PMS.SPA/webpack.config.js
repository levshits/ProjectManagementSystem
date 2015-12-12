/**
 * Created by levsh on 12/12/2015.
 */
var path = require('path');

module.exports = {
    entry: ['./src/js/main.js', './src/css/style.less'],
    output: {
        path:'./build/',
        filename: 'app.js'
    },
    watch: true,
    module:{
        loaders:[
            { test: /\.less$/, loader: 'style-loader!css-loader!less-loader' }, // use ! to chain loaders
            { test: /\.css$/, loader: 'style-loader!css-loader' },
            {
                test: /.jsx?$/,
                loader: 'babel-loader',
                exclude: /node_modules/,
                query:{
                    presets:['es2015','react']
                }
            },
            {
                test: /\.(eot|woff|woff2|ttf|svg|png|jpg)$/,
                loader: 'url-loader?limit=30000&name=[name]-[hash].[ext]'
            }
        ]
    }
};