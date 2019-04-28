var detail = function () {
    var app = new Vue({
        el: '#app',
        data: {
            pageConfig: {
                allowAddUrl: true,
                allowAddresponseheader: true,
                activeName: 'match'
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
                RequestContentType: '',
                ResponseContentType: '',
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
            backward: function () {
                window.location.href = "/mock/Rules/Pages/List/" + app.$data.editForm.ProjectId;
            },
            editforward: function () {
                window.location.href = "/mock/Rules/Pages/Edit/" + app.$data.editForm.Id;
            },
            addHeader: function () {
                app.$data.editForm.Responseheaders.push({ key: '', value: '' });
                if (app.$data.editForm.Responseheaders.length >= 5) {
                    app.$data.pageConfig.allowAddresponseheader = false;
                } else {
                    app.$data.pageConfig.allowAddresponseheader = true;
                }
            },
            deleteHeader: function (index) {
                app.$data.editForm.Responseheaders.splice(index, 1);
                if (app.$data.editForm.Responseheaders.length >= 5) {
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
                        if (!data.Result) {
                            MyMessager.alert(data);
                        } else {
                            app.editForm = data.Data;
                        }
                    }
                });
            },
            save: function () {
                $.ajax({
                    url: $('#urls').data('create'),
                    type: 'POST',
                    data: app.$data.editForm,
                    dataType: "json",
                    success: function (data) {
                        MyMessager.alert(data);
                        var newId = data.Data;
                        $.ajax({
                            url: $('#urls').data('delete') + "/" + id,
                            type: 'GET',
                            dataType: "json",
                            success: function (data) {
                                window.location.href = "/mock/Rules/Pages/Edit/" + newId;
                            }
                        });
                    }
                });
            },
            form: function () {

            },
            tabChange: function () {

            }
        }
    })
    return {
        init: function () {
            app.detail();
        }
    }
}()