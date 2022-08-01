var login = (function () {
    var configs = {
        urls: {
            login: '',
            home: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };

    function login() {
        model = $('#form-login').serializeObject();
        
        $.post(configs.urls.login, model).done(function () {
            location.href = (configs.urls.home)

        }).fail(function (msg) {
                site.toast.error(msg);
        });
    }

    return {
        init: init,
        login: login
    };
})();