var UserType = [];
var LoginVue = new Vue({
    el: '#UserType',
    methods: {
        LoginTypeMethod: function () {
            if (localStorage.getItem("LoginUser") != null) {
                window.location.href = '/User/UserPage';
            }
            else {
                $("#LoginModal").modal('show');
            }
        }

    },
})

document.querySelector('#loginBtn').addEventListener('click', function () {
    globalThis.LoginVue.LoginTypeMethod();
});
