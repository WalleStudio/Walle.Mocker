var index = function () {

    var app = new Vue({
        el: '#app',
        data: {
            Message: 'hello world',
            activeName: '0',
            noJoin: '0',
            activeName2: 'first'
        },
        methods: {
            handleClick(tab, event) {
                console.log(tab, event);
            }
        }
    })

    return {
        init: function () {

        }
    }
}()