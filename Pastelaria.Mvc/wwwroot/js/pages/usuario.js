var usuario = (function () {
    var configs = {
        urls: {
            cadastrar: '',
            cadastrarUsuario: '',
            VerTarefa: '',
            home: '',
            editarTarefa: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };

    function cadastrar() {
        model = $('#form-cadastrar').serializeObject();
        
        $.post(configs.urls.cadastrar, model).done(function () {
            site.toast.success("Tarefa cadastrada com sucesso!");

        }).fail(function (msg) {
                site.toast.error(msg);
        });
    }

    function cadastrarUsuario() {
        model = $('#form-cadastrar-usuario').serializeObject();

        $.post(configs.urls.cadastrarUsuario, model).done(function () {
            site.toast.success("Usuário cadastrado com sucesso!");
        }).fail(function(msg) {
            site.toast.error(msg);
        });
    }

    function visualizarTarefa(id) {
        var teste = $('#idTarefa').val(id);
        $.get(configs.urls.VerTarefa, teste).done(function (html){
            $('.content').hide();
            $('#Teste').show();
            $('#Teste').html(html);
        })
    
    }

    function editar() {
        model = $('#form-editar').serializeObject();
        
        $.post(configs.urls.editarTarefa, model).done(function() {
            site.toast.success("Alterado com sucesso!");
        }).fail(function(msg) {
            site.toast.error(msg);
        });
    }

    return {
        init: init,
        cadastrar: cadastrar,
        cadastrarUsuario: cadastrarUsuario,
        visualizarTarefa: visualizarTarefa,
        editar: editar
    };
})();