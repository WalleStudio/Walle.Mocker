var add = function () {
    var app = new Vue({
        el: '#app',
        data: {
            pageConfig: {
                allowAddUrl: true,
                allowAddresponseheader: true,
                activeName: 'match'
            },
            createForm: {
                ProjectId: 0,
                Name: '',
                Urls: [""],
                Desc: '',

                RequestMethod: 'POST',
                RequestBody: '',
                RequestBodyType: 'Json',
                RequestContentType: 'text/plain',

                ResponseContentType: 'text/plain',
                ResponseBody: '',
                Responseheaders: [{ Key: '', Value: '' }],
                ResponseStatusCode: '200'
            }
        },
        methods: {
            addUrl: function () {
                app.$data.createForm.Urls.push("");
                if (app.$data.createForm.Urls.length >= 3) {
                    app.$data.pageConfig.allowAddUrl = false;
                }
            },
            deleteUrl: function (index) {
                app.$data.createForm.Urls.splice(index, 1);
                if (app.$data.createForm.Urls.length >= 3) {
                    app.$data.pageConfig.allowAddUrl = false;
                } else {
                    app.$data.pageConfig.allowAddUrl = true;
                }
            },
            clearForm: function () {
                app.$data.createForm = {
                    ProjectId: 0,
                    Name: '',
                    Urls: [""],
                    Desc: '',

                    RequestMethod: 'POST',
                    RequestBody: '',
                    RequestBodyType: 'Json',
                    RequestContentType: '',

                    ResponseContentType: '',
                    ResponseBody: '',
                    Responseheaders: [{ Key: '', Value: '' }],
                    ResponseStatusCode: '200'
                };
                app.$data.createForm.Urls.splice(0, 100);
                app.$data.createForm.Urls.push("");
                app.$data.createForm.Responseheaders.splice(0, 100);
                app.$data.createForm.Responseheaders.push({ Key: '', Value: '' })
            },
            addHeader: function () {
                app.$data.createForm.Responseheaders.push({ key: '', value: '' });
                if (app.$data.createForm.Responseheaders.length >= 5) {
                    app.$data.pageConfig.allowAddresponseheader = false;
                } else {
                    app.$data.pageConfig.allowAddresponseheader = true;
                }
            },
            deleteHeader: function (index) {
                app.$data.createForm.Responseheaders.splice(index, 1);
                if (app.$data.createForm.Responseheaders.length >= 5) {
                    app.$data.pageConfig.allowAddresponseheader = false;
                } else {
                    app.$data.pageConfig.allowAddresponseheader = true;
                }
            },
            getProjectId: function () {
                app.createForm.ProjectId = $('#app').data('projectid');
            },
            save: function () {
                $.ajax({
                    url: $('#urls').data('create'),
                    type: 'POST',
                    data: app.$data.createForm,
                    dataType: "json",
                    success: function (data) {
                        MyMessager.alert(data);
                        app.getlist(app.pagination.pageIndex, app.pagination.pageSize);
                    }
                });
            },
            form: function () {

            },
            tabChange: function () {

            },
            backward: function () {
                app.createForm.ProjectId = $('#app').data('projectid');
                window.location.href = "/mock/Rules/Pages/List/" + app.$data.createForm.ProjectId;
            },
        }
    })
    return {
        init: function () {
            app.getProjectId();
        }
    }
}()