
    function checkinput(){
        masp=document.product.MASP;
        tensp=document.product.TENSP;
        giasp=document.product.GIASP;
        loaisp=document.product.LOAISP;
        kcosp=document.product.KCOSP;
        pgiaisp=document.product.PGIAISP;
        hdhsp=document.product.HDHSP;
        cpusp=document.product.CPUSP;
        ramsp=document.product.RAMSP;
        bnhosp=document.product.BNHOSP;
        pinsp=document.product.PINSP;
        camsp=document.product.CAMSP;
        hinhsp = document.product.HINHSP;
        if(masp.value==""){
            alert("Hãy nhập mã sản phẩm");
            masp.focus();
            return false;
        }
        if(tensp.value==""){
            alert("Hãy nhập tên sản phẩm");
            tensp.focus();
            return false;
        }
        if(giasp.value==""){
            alert("Hãy nhập giá sản phẩm");
            giasp.focus();
            return false;
        }
        if(loaisp.value==""){
            alert("Hãy nhập loại sản phẩm");
            loaisp.focus();
            return false;
        }
        if(kcosp.value==""){
            alert("Hãy nhập kích thước màn hình");
            kcosp.focus();
            return false;
        }
        if(pgiaisp.value==""){
            alert("Hãy nhập độ phân giải màn hình");
            pgiaisp.focus();
            return false;
        }
        if(hdhsp.value==""){
            alert("Hãy nhập tên hệ điều hành");
            hdhsp.focus();
            return false;
        }
        if(cpusp.value==""){
            alert("Hãy nhập loại CPU");
            cpusp.focus();
            return false;
        }
        if(ramsp.value==""){
            alert("Hãy nhập dung lượng RAM");
            ramsp.focus();
            return false;
        }
        if(bnhosp.value==""){
            alert("Hãy nhập dung lượng bộ nhớ");
            bnhosp.focus();
            return false;
        }
        if(pinsp.value==""){
            alert("Hãy nhập dung lượng Pin");
            pinsp.focus();
            return false;
        }
        if(camsp.value==""){
            alert("Hãy nhập độ phân giải camera");
            camsp.focus();
            return false;
        }
        if(hinhsp.value==""){
            alert("Hãy tải lên hình ảnh sản phẩm");
            hinhsp.focus();
            return false;
        }        
        return true;
    }