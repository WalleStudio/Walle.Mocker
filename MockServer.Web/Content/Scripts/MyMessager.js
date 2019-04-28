/**
 * 配合系统JsonMessage对象使用
 */
var MyMessager = function () {
    var app = new Vue({
        el: "#myMessager"
    })
    return {
        alert: function (msg) {
            if (msg.Type === 1) {
                app.$message({
                    message: msg.Message,
                    type: 'success'
                });
            } else if (msg.Type === 2) {
                app.$message({
                    message: msg.Message,
                    type: 'info'
                });

            } else if (msg.Type === 3) {
                app.$message({
                    message: msg.Message,
                    type: 'warning'
                });
            } else if (msg.Type === 4) { //4为 拒绝访问 提示并跳转到登录页面
                app.$message({
                    message: msg.Message,
                    type: 'error'
                });
                if (msg.data != null) {
                    widow.location.open(msg.data);
                }
            } else {
                app.$message({
                    message: msg.Message,
                    type: 'error'
                });
            }
        }
    }
}()