var add = function () {
    var app = new Vue({
        el: '#app',
        data: {
            project: {
                Name: '',
                Description: '',
                Owner: ''
            },
            rules: {
                name: [
                    { required: true, message: '请输入系统名称！', trigger: 'blur' }
                ],
                description: [
                    { required: true, message: '请填写系统描述！', trigger: 'blur' }
                ]
            },
            users: []
        },
        methods: {
            submitForm: function (formName) {
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        $.ajax({
                            type: 'POST',
                            url: $('#urls').data('add'),
                            dataType: 'json',
                            data: app.$data.project,
                            success: function (data) {
                                MyMessager.alert(data);
                            }
                        })
                    } else {
                        return false;
                    }
                });
            },
            resetForm: function (formName) {
                this.$refs[formName].resetFields();
            },
            loadData: function () {
                $.ajax({
                    url: $('#urls').data('users'),
                    dataType: 'json',
                    success: function (data) {
                        $.each(data, function (index, value) {
                            app.$data.users.push(value);
                        })
                    }
                });
                $.ajax({
                    url: $('#user').data('url'),
                    dataType: 'json',
                    type: 'GET',
                    success: function (data) {
                        app.$data.project.Owner = data.UserName + data.WorkId;
                    }
                })
            }
        }
    })


    return {
        init: function () {
            app.loadData();
        }
    }
}()