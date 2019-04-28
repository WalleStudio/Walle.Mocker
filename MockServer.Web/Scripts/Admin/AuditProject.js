var auditProject = function () {
  
    //分页
    var pagination = {
        total: 0,
        currentPage: 1,
        pageSize: 5
    }


    var projects = [];

    var app = new Vue({
        el: '#app',
        data: {
            activeName: 'AuditProject',
            pagination: pagination,
            projects: projects
        },
        methods: {
            handleCurrentChange(val) {
                pagination.currentPage = val;
                loadProjectData(val, pagination.pageSize, app.activeName);
            },
            handleSizeChange(val) {
                pagination.pageSize = val;
                loadProjectData(pagination.currentPage, val, app.activeName);
            },
            dialogClick(index,b,id) {
                projects[index].AuditDialogVisible = b;
                if (id != null && id != 0) {
                    audit(b, id)
                    projects[index].AuditDialogVisible = false;
                    
                }
            }
        }
    })

    //加载数据
    var loadProjectData = function (currentPage, pageSize, type) {
        $.ajax({
            url: $('#urls').data('auditproject'),
            method: 'POST',
            data: { currentPage: currentPage, pageSize: pageSize, type: type },
            dataType: 'json',
            success: function (rsp) {
                if (rsp.Result) {
                    pagination.total = rsp.Data.TotalCount;
                    projects.splice(0, projects.length);
                    $.each(rsp.Data.DetailInfo, function (index, value) {
                        projects.push(value);
                    })
                }
                else {
                    projects.splice(0, projects.length);
                    pagination.total = 0;
                }
            }
        });
    }

    var audit = function(b,id)
    {
        $.ajax({
            url: $('#urls').data('audit'),
            method: 'POST',
            data: { id: id, b: b },
            dataType: 'json',
            success: function (data) {
                if (data.Result) {
                    app.$notify({
                        title: '执行成功',
                        message: data.Msg,
                        type: 'success'
                    });
                    loadProjectData(1, 5, app.activeName);
                }
            },
            error:function(data){
                alert(data);
            }
        })
    }

    return {
        init: function () {
            loadProjectData(1, 5, app.activeName);
        }
    }
}()