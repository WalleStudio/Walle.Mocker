var edit = function () {
    var app = new Vue({
        el: '#app',
        data: {
            pageConfig: {
                allowAddUrl: true,
                allowAddresponseheader: true,
                activeName: 'base'
            },

            editForm: {
                ProjectId: 0,
                Id: 0,
                Name: '',
                Urls: [""],
                Desc: '',
                RequestMethod: 'POST',
                RequestBody: '',
                RequestHeaders: [{ Key: '', Value: '' }],
                RequestContentType: 'text/plain',
                ResponseContentType: 'text/plain',
                ResponseBody: '',
                ResponseHeaders: [{ Key: '', Value: '' }],
                ResponseStatusCode: '200'
            }
        },
        methods: {
            addUrl: function () {
                app.$data.editForm.Urls.push("");
                if (app.$data.editForm.Urls.length >= 3) {
                    app.$data.pageConfig.allowAddUrl = false;
                }
            },
            deleteUrl: function (index) {
                app.$data.editForm.Urls.splice(index, 1);
                if (app.$data.editForm.Urls.length >= 3) {
                    app.$data.pageConfig.allowAddUrl = false;
                } else {
                    app.$data.pageConfig.allowAddUrl = true;
                }
            },
            retBack: function () {
                window.location.href = "/mock/Rules/Pages/Detail/" + app.$data.editForm.Id;
            },
            addHeader: function () {
                app.$data.editForm.ResponseHeaders.push({ key: '', value: '' });
                if (app.$data.editForm.ResponseHeaders.length >= 5) {
                    app.$data.pageConfig.allowAddresponseheader = false;
                } else {
                    app.$data.pageConfig.allowAddresponseheader = true;
                }
            },
            deleteHeader: function (index) {
                app.$data.editForm.ResponseHeaders.splice(index, 1);
                if (app.$data.editForm.ResponseHeaders.length >= 5) {
                    app.$data.pageConfig.allowAddresponseheader = false;
                } else {
                    app.$data.pageConfig.allowAddresponseheader = true;
                }
            },
            detail: function () {
                app.editForm.Id = $('#app').data('ruleid');
                $.ajax({
                    url: $('#urls').data('detail') + "/" + app.editForm.Id,
                    type: 'GET',
                    dataType: "json",
                    success: function (data) {
                        app.editForm = data.Data;
                        if (app.editForm.ResponseHeaders.length == 0) {
                            app.$data.editForm.ResponseHeaders.push({ key: '', value: '' });
                        }
                    }
                });
            },
            update: function () {
                $.ajax({
                    url: $('#urls').data('update'),
                    type: 'POST',
                    data: app.$data.editForm,
                    dataType: "json",
                    success: function (data) {
                        MyMessager.alert(data);
                        if (data.Result) {
                            var newId = data.Data;
                            window.location.href = "/mock/Rules/Pages/Detail/" + newId;
                        }
                    }
                });
            },
            form: function () {

            },
            tabChange: function (tab, event) {
                app.$data.pageConfig.activeName = tab.name;
            },
            next: function () {
                if (app.$data.pageConfig.activeName == 'base') {
                    app.$data.pageConfig.activeName = 'match';
                } else if (app.$data.pageConfig.activeName == "match") {
                    app.$data.pageConfig.activeName = 'exp';
                }
            },
            previous: function () {
                if (app.$data.pageConfig.activeName == 'match') {
                    app.$data.pageConfig.activeName = 'base';
                } else if (app.$data.pageConfig.activeName == "exp") {
                    app.$data.pageConfig.activeName = 'match';
                }
            }
        }
    })
    return {
        init: function () {
            app.detail();
        }
    }
}()