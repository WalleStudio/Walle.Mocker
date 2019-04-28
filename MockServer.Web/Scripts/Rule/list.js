var list = function () {
    var app = new Vue({
        el: '#app',
        data: {
            pageConfig: {
                showProjectSettingDialog: false
            },
            pagination: {
                pageIndex: 1,
                pageSize: 10,
                pageTotal: 0
            },
            ListItemDanger: {
                '': true ,'todo-tasklist-item-border-danger': true
            },
            ListItemSuccess: {
                'todo-tasklist-item': true, 'todo-tasklist-item-border-success': true
            },
            RuleList: [
                { Name: '', Desc: '', RequestMethod: 'Get', IsActive: true }
            ],
            project: {
                Id: null,
                Name: null,
                Url: null,
                Description: null
            }
        },
        methods: {
            getlist: function (startIndex, pageSize) {
                app.project.Id = $('#app').data('projectid');
                $.ajax({
                    url: $("#urls").data('list') + "?startIndex=" + startIndex + "&pageSize=" + pageSize + "&ProjectId=" + app.project.Id,
                    type: 'GET',
                    dataType: 'json',
                    success: function (result) {
                        app.RuleList.splice(0, app.RuleList.length);
                        if (result.Data != null && result.Data.RuleList != null) {
                            $.each(result.Data.RuleList, function (index, item) {
                                app.RuleList.push(item);
                            });
                            app.pagination.pageTotal = result.Data.Total;
                        }
                    }
                })
            },
            createRule: function () {
                window.location.href = "/mock/Rules/Pages/Add/" + app.project.Id;
            },
            detail: function (id) {
                window.location.href = "/mock/Rules/Pages/Detail/" + id;
            },
            del: function (id) {
                $.ajax({
                    url: $('#urls').data('delete') + "/" + id,
                    type: 'GET',
                    dataType: "json",
                    success: function (data) {
                        MyMessager.alert(data);
                        app.pageConfig.showDetailDialog = false;
                        app.getlist(app.pagination.pageIndex, app.pagination.pageSize);
                    }
                });
            },
            frozen: function (item) {
                $.ajax({
                    url: $('#urls').data('frozen') + "/" + item.Id,
                    type: 'GET',
                    dataType: "json",
                    success: function (data) {
                        MyMessager.alert(data);
                        item.IsActive = false;
                    }
                });
            },
            active: function (item) {
                $.ajax({
                    url: $('#urls').data('active') + "/" +item.Id,
                    type: 'GET',
                    dataType: "json",
                    success: function (data) {
                        MyMessager.alert(data);
                        item.IsActive = true;
                    }
                });
            },
            form: function () {

            },
            projectDetail: function () {
                app.project.Id = $('#app').data('projectid');
                $.ajax({
                    url: $("#urls").data('projdetail') + "/" + app.project.Id,
                    type: 'GET',
                    dataType: 'json',
                    success: function (result) {
                        app.project = result.Data;
                    }
                });
            },
            projectEdit: function () {
                $.ajax({
                    url: $('#urls').data('projedit'),
                    method: 'POST',
                    data: app.$data.project,
                    dataType: 'json',
                    success: function (data) {
                        if (data.Result) {
                            app.pageConfig.showProjectSettingDialog = false;
                        }
                        MyMessager.alert(data);
                    }
                })
            },
            pageSizeChange: function (val) {
                app.pagination.pageSize = val;
                app.getlist(app.pagination.pageIndex, app.pagination.pageSize);
            },
            pageCurrentChange: function (val) {
                app.pagination.pageIndex = val;
                app.getlist(app.pagination.pageIndex, app.pagination.pageSize);
            }
        }
    })
    return {
        init: function () {
            app.getlist(app.pagination.pageIndex, app.pagination.pageSize);
            app.projectDetail();
        }
    }
}()