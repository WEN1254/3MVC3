var CustomerInfo = new Vue({
    el: '#UserData',
    data: {
        isBusy: true,
        UserData: {},
    },
    created: function () {
        console.log("LoginUser");
        let UserType = {
            LoginUser: localStorage.getItem("LoginUser")
        }

        $.ajax({
            url: '/api/CustomerManager/GetCustomer',
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(UserType),
            async: true,
            success: function (response) {
                console.log(response);
                if (response.StatusCode == '1') {
                    console.log(UserType);
                    GetResponse(response.Result);
                    BusyChange();
                }
                else {
                    console.log(UserType);
                }
            }
        });

        function GetResponse(input) {
            this.CustomerInfo.UserData = input;
            console.log(this.CustomerInfo.UserData);
        }
        function BusyChange() {
            this.CustomerInfo.isBusy = !this.CustomerInfo.isBusy;
        }
    },
});