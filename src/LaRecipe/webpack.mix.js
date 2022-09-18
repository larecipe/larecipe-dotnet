let mix = require('laravel-mix');

mix.copy('node_modules/@larecipe/larecipe-ui/dist/app.js', 'Web')
    .copy('node_modules/@larecipe/larecipe-ui/dist/app.css', 'Web')
    .setPublicPath("Web")
    .version();