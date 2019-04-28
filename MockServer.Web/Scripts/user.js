var User = function () {
    var app = new Vue({
        el: "#user",
        data: {
            user: {  }
        }
    })

    var getUserInfo = function () {
        var url = $('#user').data('url');
        $.ajax({
            url: url,
            method: 'get',
            contentType: 'json',
            complete: function (data) {
                var user = JSON.parse(data.responseText);
                app.$data.user = user
            }
        })
    }

    return {
        init: function () {
            getUserInfo();
        }
    }
}()