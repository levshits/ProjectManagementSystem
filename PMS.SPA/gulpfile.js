/**
 * Created by levsh on 12/5/2015.
 */
var gulp = require('gulp');
var browserify = require('browserify');
var source = require('vinyl-source-stream');
var del = require('del');
var browserSync = require('browser-sync');
var concat = require('gulp-concat');
var rename = require('gulp-rename');
var less = require('gulp-less');
var autoprefixer = require('gulp-autoprefixer');

sourceFile = './src/js/main.js',
destFileName = 'app.js';

gulp.task('clean', function (cb) {
    return del('./dist/*.js', cb);
});

gulp.task('build', function () {
    return browserify({entries: sourceFile, extensions: ['.js'], debug: true})
        .transform("babelify", {presets: ["es2015", "react"]})
        .bundle()
        .pipe(source(destFileName))
        .pipe(gulp.dest('dist'));
});

gulp.task('browserSync', function () {
    return browserSync({
        port: 9000,
        open: false,
        server: {
            baseDir: ['./dist']
        },
        files: ['./dist/**']
    });
});


gulp.task('watch', ['clean', 'build', 'browserSync'], function () {
    gulp.watch('src/js/*/**.js', ['build']);
});

gulp.task('default', ['watch']);