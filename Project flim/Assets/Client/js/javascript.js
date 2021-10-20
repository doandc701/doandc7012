function send(){
    var arr = document.getElementsByTagName('input');
    var tendangnhap= arr[0].value;
    var email= arr[1].value;
    var sodienthoai= arr[2].value;
    var matkhau= arr[3].value;
    var nhaplaimatkhau= arr[4].value;
    if(tendangnhap == "" || email == "" || sodienthoai== "" || matkhau == "" || nhaplaimatkhau == "" ){
        alert("Vui lòng điền đầy đủ thông tin!");
        return;
    }

    if(isNaN(sodienthoai) || sodienthoai.length <10){
        alert("Vui lòng điền đúng số điện thoại");
        return;
    }
    if(matkhau != nhaplaimatkhau){
        alert("Vui lòng nhập đúng mật khẩu");
        return;
    }
    if(tendangnhap.length <5){
        alert("Tên đăng nhập phải từ 6-20 kí tự");
        return;
    }
    confirm('Tên đăng nhập: '+tendangnhap+"\n"+
            'Email: '+email+"\n"+
            'Số điện thoại: '+sodienthoai+"\n"+
            'Mật khẩu: '+matkhau
    )
}