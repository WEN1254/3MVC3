var UserType = [];
var a = new Vue({
    el: '#LoginModal',
    data: {
        LoginEmail: '',
        LoginPassword: '',
        LoginerrorMsg: '',
        LoginPassworderrorMsg: ''
    },
    methods: {
        LoginMethod: function () {
            console.log('login');
            let data = {
                LoginEmail: this.LoginEmail,
                LoginPassword: this.LoginPassword
            }
            $.ajax({
                url: '/api/CustomerManager/Login',
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(data),
                async: true,
                success: function (response) {
                    console.log(response);
                    if (response.StatusCode == '1') {
                        UserType.push({ data })
                        localStorage.setItem("LoginUser", data.LoginEmail);
                        window.location.href = '/Home/Index';
                    }
                    else if (response.StatusCode == '2') {
                        alert("此帳戶不存在");
                    } else {
                        alert("密碼錯誤");
                    }
                }
            });
        },
        
        
    },
})