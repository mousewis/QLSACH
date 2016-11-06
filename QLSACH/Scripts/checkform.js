
    function checkinput(){
        username=document.signup.username;
        password=document.signup.password;
        hoten=document.signup.hoten;
        diachi=document.signup.diachi;
        email=document.signup.email;
        dienthoai=document.signup.dienthoai;
        reg1=/^[0-9A-Za-z]+[0-9A-Za-z_]*@[\w\d.]+.\w{2,4}$/;
        testmail=reg1.test(email.value);
        if(username.value==""){
            alert("Hãy chọn tên đăng nhập");
            username.focus();
            return false;
        }
        if(password.value==""){
            alert("Chưa nhập mật khẩu");
            password.focus();
            return false;
        }
        if(hoten.value==""){
            alert("Hãy nhập vào họ tên của bạn");
            hoten.focus();
            return false;
        }
        if(diachi.value==""){
            alert("Chưa nhập địa chỉ");
            diachi.focus();
            return false;
        }
        if(!testmail){
            alert("Địa chỉ email không hợp lệ");
            email.focus();
            return false;
        }
        if(isNaN(dienthoai.value)){
            alert("Số điện thoại chưa chính xác");
            dienthoai.focus();
            return false;
        }
        return true;
    }