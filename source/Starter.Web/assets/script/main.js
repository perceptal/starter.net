require.config({
    baseUrl: "/assets/script/",
    paths: {
          jquery: "../vendor/script/jquery-1.7.1"
        , underscore: "../vendor/script/underscore-1.3.1"
        , backbone: "../vendor/script/backbone-0.9.1"
        , handlebars: "../vendor/script/handlebars-1.0.0.beta.6"
        , text: "../vendor/script/require-text-1.0.7"
        , domready: "../vendor/script/require-domready-1.0.0"
        , order: "../vendor/script/require-order-1.0.5"
        , i18n: "../vendor/script/require-i18n-1.0.0"
        , cs: "../vendor/script/require-cs-0.3.2"
    },
    waitSeconds: 2,

    // For easier development, disable browser caching:
    urlArgs: 'bust=' + (new Date()).getTime()
});

require(["domready", "app"], function (domready, app) {
    domready(function () {
        app.initialize(); 
    });
});