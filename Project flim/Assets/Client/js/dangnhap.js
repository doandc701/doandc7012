function send(){
    var arr =document.getElementsByTagName('input');
    var nhaptaikhoan= arr[0].value;
    var nhapmatkhau= arr[1].value;
    if(nhaptaikhoan == "" || nhapmatkhau == ""){
        alert("Bạn chưa nhập tài khoản và mật khẩu!");
        return;
    }
    
}