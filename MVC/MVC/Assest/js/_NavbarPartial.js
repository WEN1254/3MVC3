function shop() {
    var check = document.getElementById("check");
    var body = document.getElementById("body");


    var value = check.checked;

    if (check.checked == true) {
        // body.style.opacity = '0.6';
        //   shop.style.opacity = '1';
        check.checked = false;
    }
    else {
        // var shop = document.querySelector("#shop"); 

        check.checked = true;
    }
}




