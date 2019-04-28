var Menu = function () {
    var app = new Vue({
        el: "#menu",
        data: {
            Menus: [],

        }
    })

    /*
     * 实时加载菜单
     */
    var getMenu = function () {
        var url = $('#menu').data('url');
        $.ajax({
            url: url,
            method: 'get',
            contentType: 'json',
            complete: function (data) {
                app.$data.Menus.splice(0, 1000);
                var menu = JSON.parse(data.responseText);
                $.each(menu.Modules, function () {
                    app.$data.Menus.push(this);
                })
            }
        })
    }

    return {
        init: function () {
            getMenu();
        }
    }
}()