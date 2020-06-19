var Register = new Vue({
    el: '#RegisterModel',
    data: {
        RegisterCustomerName: '',
        RegisterPhone: '',
        RegisterPassword: '',
        RegisterBirthday: '',
        RegisterEmail: '',
    },
    methods: {
        Register: function () {
            console.log('test');
            let data = {
                RegisterCustomerName: this.RegisterCustomerName,
                RegisterPhone: this.RegisterPhone,
                RegisterPassword: this.RegisterPassword,
                RegisterBirthday: this.RegisterBirthday,
                RegisterEmail: this.RegisterEmail
            }
            $.ajax({
                url: '/api/CustomerManager/Register',
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(data),
                success: function (response) {
                    console.log(response);
                    if (response.StatusCode == '1') {
                        window.location.href = '/Home/Index';
                    }
                    else {
                        alert("此信箱已重複");


                    }
                }
            });
        }
    }
}
)
