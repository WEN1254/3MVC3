var CustomerInfo = new Vue({
    el: '#UserData-Context',
    data: {
        UserData: [
            {
                Email: ''
            }
        ],
        UserOrderData:
            [
                {
                }
            ],
        tabIndex: 0,
    },
    created: function () {
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

                if (response.StatusCode == '1') {
                    GetResponse(response.Result);
                }
                else {
                    console.log(UserType);
                }
            }
        });
        
        function GetResponse(input) {
            console.log(input);
            this.CustomerInfo.UserData = input;
        }

        let UserOrderEmail = {
            LoginUser: localStorage.getItem("LoginUser")
        }

        $.ajax({
            url: '/api/CustomerManager/GetOrder',
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(UserOrderEmail),
            async: true,
            success: function (response) {
                
                if (response.StatusCode == '1') {
                    GetOrderResponse(response.Result);
                    
                }
                else {
                    console.log(UserOrderEmail);
                }
            }
        });

        function GetOrderResponse(input) {
            console.log(input);
            this.CustomerInfo.UserOrderData = input.groupByOrderID('OrderId');
            console.log(this.CustomerInfo.UserOrderData);
        }
        
    },
    methods: {
        Replace: function () {
            let data = {
                ReplaceEmail: this.UserData[0].Email,
                ReplaceCustomerName: this.UserData[0].CustomerName,
                ReplaceBirthDay: this.UserData[0].BirthDay,
                ReplacePhone: this.UserData[0].Phone,
                ReplacePassword: this.UserData[0].Password
            }
            console.log(data);
            $.ajax({
                url: '/api/CustomerManager/Replace',
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(data),
                success: function (response) {
                    console.log(response);
                    swal({
                        title: "Success!",
                        text: "Your data has been uploaded",
                        icon: "success",
                        confirmButtontext: "I know!",
                        showCancelButton: true,
                        closeOnConfirm: false
                    })
                }
            });
        },
        
    }

});
Array.prototype.groupByOrderID = function (prop) {
    return this.reduce(function (groups, item) {
        const val = item['OrderID']
        groups[val] = groups[val] || []
        groups[val].push(item)
        return groups
    }, {})
};










