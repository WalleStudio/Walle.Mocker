var index = function () {
    //Begin-Url
    var queryProjectUrl = null;
    var applyJoinProjectUrl = null;
    var editProjectUrl = null;

    var initUrls = function () {
        var urls = $('#urls');
        queryProjectUrl = urls.data('project');
        applyJoinProjectUrl = urls.data('apply');
        editProjectUrl = urls.data('edit');
    }
    //End  

    //分页
    var pagination = {
        total: 0,
        currentPage: 1,
        pageSize: 5
    }

    var projects = [];

    var projectClone = {
        Id: null,
        Name: null,
        Url: null,
        Description: null
    };

    var app = new Vue({
        el: '#app',
        data: {
            activeName: 'Joined',
            pagination: pagination,
            projects: projects,
            projectClone: projectClone
        },
        methods: {
            handleClick(tab, event) {
                pagination.currentPage = 1;
                pagination.pageSize = 5;
                loadProjectData(pagination.currentPage, pagination.pageSize, app.activeName);
            },
            handleCurrentChange(val) {
                pagination.currentPage = val;
                loadProjectData(val, pagination.pageSize, app.activeName);
            },
            handleSizeChange(val) {
                pagination.pageSize = val;
                loadProjectData(pagination.currentPage, val, app.activeName);
            },
            dialogClick(index, b, id) {
                projects[index].ApplyDialogVisible = b;
                if (id != null && id != 0) {
                    $.ajax({
                        url: applyJoinProjectUrl,
                        method: 'POST',
                        data: { id: id },
                        dataType: 'json',
                        success: function (data) {
                            if (data.Result) {
                                projects[index].IsApply = true;
                            }
                            MyMessager.alert(data);
                        }
                    })
                }
            },
            ruleList: function (projectId) {
                window.location.href = "/mock/Rules/Pages/List/" + projectId;
            },
            editProject: function (projectClone, project) {
                var isReq = false;
                if (project.Name != projectClone.Name) {
                    isReq = true;
                }
                else if (project.Url != projectClone.Url) {
                    isReq = true;
                }
                else if (project.Description != projectClone.Description) {
                    isReq = true;
                }
                if (isReq) {
                    $.ajax({
                        url: editProjectUrl,
                        method: 'POST',
                        data: projectClone,
                        dataType: 'json',
                        success: function (data) {
                            if (data.Result) {
                                project.Name = projectClone.Name;
                                project.Url = projectClone.Url;
                                project.Description = projectClone.Description;
                                project.EditDialogVisible = false;
                            }
                            MyMessager.alert(data);
                        }
                    })
                }
                else {
                    project.EditDialogVisible = false;
                }
            },
            cloneProject: function (project) {
                projectClone.Id = project.Id;
                projectClone.Name = project.Name;
                projectClone.Url = project.Url;
                projectClone.Description = project.Description;
                project.EditDialogVisible = true;
            },
            createProject: function () {
                window.location.href = "/mock/Projects/Pages/Add";
            },
        }
    })

    //加载数据
    var loadProjectData = function (currentPage, pageSize, type) {
        $.ajax({
            url: queryProjectUrl,
            method: 'POST',
            data: { currentPage: currentPage, pageSize: pageSize, type: type },
            dataType: 'json',
            success: function (rsp) {
                if (rsp.Result) {
                    projects.splice(0, projects.length);
                    pagination.total = rsp.Data.TotalCount;
                    $.each(rsp.Data.DetailInfo, function (index, value) {
                        projects.push(value);
                    })
                }
                else {
                    projects.splice(0, projects.length);
                    pagination.total = 0;
                    MyMessager.alert(rsp);
                }
            }
        });
    }

    return {
        init: function () {
            initUrls();
            loadProjectData(1, 5, app.activeName);
        }
    }
}()