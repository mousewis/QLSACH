//function themctphieunhap() {
//    ///themctphieunhap
//    if (!checkctphieunhap())
//        return false;
//    var masach = document.getElementById("masach");
//    var temp = masach.value;
//    //var breakout = false;
//    //$("#sachIndex").each(function () {
//    //    alert(this.val());
//    //    if (this.val() == temp)
//    //    {
//    //        $("#ctphieunhap[" + this.val() + "].soluong").val(function () {
//    //            return this.val() + temp;
//    //        });
//    //        $("#sach[" + this.val() + "].sluong").val(function () {
//    //            return this.val() + temp;
//    //        });
//    //        $("#ctphieunhap[" + this.val() + "].thanhtien").val(function () {
//    //            return Number($("#ctphieunhap[" + this.val() + "].soluong").val()) * Number($("#ctphieunhap[" + this.val() + "].gia").val());
//    //        });
//    //        breakout = true;
//    //        return false;
//    //    }
//    //});
//    //if (breakout == true)
//    //{
//    //    breakout = false;
//    //    return false;
//    //}
//    //var masach = document.getElementById("masach");
//    //var temp = masach.value;

//    if (document.getElementsByClassName("sachIndex").length > 0) {
//        //alert(document.getElementsByClassName("sachIndex").length);
//        for (var j = 0; j < document.getElementsByClassName("sachIndex").length; j++) {
//            var r = document.getElementsByClassName("sachIndex")[j].value;
//            ////alert(r);
//            if (document.getElementById("ctphieunhap[" + r + "].masach").value == temp) {
//                //document.getElementById("ctphieunhap[" + r + "].soluong").value = Number(document.getElementById("ctphieunhap[" + r + "].soluong").value) + Number(document.getElementById("sluong").value);
//                //document.getElementById("sach[" + r + "].sluong").value += document.getElementById("sluong").value;
//                //document.getElementById("ctphieunhap[" + r + "].thanhtien").value =
//                //    Number(document.getElementById("ctphieunhap[" + r + "].soluong").value) * Number(document.getElementById("ctphieunhap[" + r + "].gia").value);
//                //var tongtien = Number(document.getElementById("phieunhap.tongtien").value);
//                //tongtien += Number(document.getElementById("ctphieunhap[" + r + "].thanhtien").value);
//                //document.getElementById("phieunhap.tongtien").value = tongtien;
//                //document.getElementById("nxb.tonkho").value = tongtien;
//                //return false;
//                alert("Thông tin sách đã tồn tại!");
//                return false;
//            }
//        }
//    }
//    i++;
//        var row = document.createElement("tr");
//        row.id = "ctphieunhap["+i+"]";
//        var col = document.createElement("td");
//        ///create input masach
//        var col1 = document.createElement("td");
//        var inp1 = document.createElement("input");
//        inp1.type = "text";
//        inp1.name = "ctphieunhap[" + i + "].masach";
//        inp1.id = "ctphieunhap[" + i + "].masach";
//        inp1.readOnly = true;
//        inp1.value = document.getElementById("masach").value;
//    ///ctphieunhap.mapn
//        var inpms = document.createElement("input");
//        inpms.type = "hidden";
//        inpms.name = "ctphieunhap[" + i + "].maso";
//        inpms.id = "ctphieunhap[" + i + "].maso";
//        inpms.value = document.getElementById("phieunhap.maso").value;
//    ///sach.masach
//        var inp1s = document.createElement("input");
//        inp1s.type = "hidden";
//        inp1s.name = "sach[" + i + "].masach";
//        inp1s.id = "sach[" + i + "].masach";
//        inp1s.value = document.getElementById("masach").value;
//    ///index sach
//        var inpId = document.createElement("input");
//        inpId.type = "hidden";
//        inpId.name = "sach.Index";
//        inpId.id = "sach.Index";
//        inpId.className = "sachIndex";
//        inpId.value = i;
//    ///index sach
//        var inpIds = document.createElement("input");
//        inpIds.type = "hidden";
//        inpIds.name = "ctphieunhap.Index";
//        inpIds.id = "ctphieunhap.Index";
//        inpIds.value = i;
//    ///append
//        col1.appendChild(inp1);
//        col1.appendChild(inp1s);
//        col1.appendChild(inpms);
//        col1.appendChild(inpId);
//        col1.appendChild(inpIds);
//        row.appendChild(col1);
//        ///create input sluong
//        var col2 = document.createElement("td");
//        var inp2 = document.createElement("input");
//        inp2.type = "number";
//        inp2.name = "ctphieunhap[" + i + "].soluong";
//        inp2.id = "ctphieunhap[" + i + "].soluong";
//        inp2.min = 1;
//        inp2.onchange = sluong_ct;
//        inp2.value = document.getElementById("sluong").value;
//    ///sach.sluong
//        var inp2s = document.createElement("input");
//        inp2s.type = "hidden";
//        inp2s.name = "sach[" + i + "].sluong";
//        inp2s.id = "sach[" + i + "].sluong";
//        inp2s.value = document.getElementById("sluong").value;
//        col2.appendChild(inp2);
//        col2.appendChild(inp2s);
//        row.appendChild(col2);
//        ///create input gia
//        var col3 = document.createElement("td");
//        var inp3 = document.createElement("input");
//        inp3.type = "text";
//        inp3.name = "ctphieunhap[" + i + "].gia";
//        inp3.id = "ctphieunhap[" + i + "].gia";
//        inp3.readOnly = true;
//        inp3.value = document.getElementById("gia").value;
//    ///sach.gia
//        col3.appendChild(inp3);
//        row.appendChild(col3);
//        ///create input thanhtien
//        var col4 = document.createElement("td");
//        var inp4 = document.createElement("input");
//        inp4.type = "text";
//        inp4.name = "ctphieunhap[" + i + "].thanhtien";
//        inp4.id = "ctphieunhap[" + i + "].thanhtien";
//        inp4.readOnly = true;
//        inp4.value = Number(inp2.value) * Number(inp3.value);
//    ////sach.tensach
//        var inp4s = document.createElement("input");
//        inp4s.type = "hidden";
//        inp4s.name = "sach[" + i + "].tensach";
//        inp4s.id = "sach[" + i + "].tensach";
//        inp4s.value = document.getElementById("tensach").value;
//        col4.appendChild(inp4);
//        col4.appendChild(inp4s);
//        row.appendChild(col4);
//        ///create input delete
//        var col5 = document.createElement("td");
//        var inp5 = document.createElement("a");
//        inp5.text = "Xóa";
//        inp5.href = "javascript:xoactphieunhap("+i+")";
//    ///sach.linhvuc
//        var inp5s = document.createElement("input");
//        inp5s.type = "hidden";
//        inp5s.name = "sach[" + i + "].linhvuc";
//        inp5s.id = "sach[" + i + "].linhvuc";
//        inp5s.value = document.getElementById("linhvuc").value;
//        col5.appendChild(inp5);
//        col5.appendChild(inp5s);
//        row.appendChild(col5);
//        document.getElementById("ds-sach").appendChild(row);
//        ////tong tien
//        var tongtien = Number(document.getElementById("phieunhap.tongtien").value);
//        tongtien += Number(inp4.value);
//        document.getElementById("phieunhap.tongtien").value = tongtien;
//        document.getElementById("nxb.tonkho").value = tongtien;
//}
function themctphieunhap() {
    ///themctphieunhap
    if (!checkctphieunhap())
        return false;
    var masach = document.getElementById("_masach");
    var temp = masach.value;
    if (document.getElementsByClassName("ctphieunhapIndex").length > 0) {
        //alert(document.getElementsByClassName("sachIndex").length);
        for (var j = 0; j < document.getElementsByClassName("ctphieunhapIndex").length; j++) {
            var r = document.getElementsByClassName("ctphieunhapIndex")[j].value;
            ////alert(r);
            if (document.getElementById("ctphieunhap[" + r + "].masach").value == temp) {
                alert("Thông tin sách đã tồn tại!");
                return false;
            }
        }
    }
    i++;
    var row = document.createElement("tr");
    row.id = "ctphieunhap[" + i + "]";
    var col = document.createElement("td");
    ///create input masach
    var col1 = document.createElement("td");
    var inp1 = document.createElement("input");
    inp1.type = "text";
    inp1.name = "ctphieunhap[" + i + "].masach";
    inp1.id = "ctphieunhap[" + i + "].masach";
    inp1.readOnly = true;
    inp1.value = document.getElementById("_masach").value;
    ///ctphieunhap.mapn
    var inpms = document.createElement("input");
    inpms.type = "hidden";
    inpms.name = "ctphieunhap[" + i + "].maso";
    inpms.id = "ctphieunhap[" + i + "].maso";
    inpms.value = document.getElementById("phieunhap.maso").value;
    ///sach.masach
    var inpIds = document.createElement("input");
    inpIds.type = "hidden";
    inpIds.name = "ctphieunhap.Index";
    inpIds.id = "ctphieunhap.Index";
    inpIds.className = "ctphieunhapIndex";
    inpIds.value = i;
    ///append
    col1.appendChild(inp1);
    col1.appendChild(inpms);
    col1.appendChild(inpIds);
    row.appendChild(col1);
    ///create input sluong
    var col2 = document.createElement("td");
    var inp2 = document.createElement("input");
    inp2.type = "number";
    inp2.name = "ctphieunhap[" + i + "].soluong";
    inp2.id = "ctphieunhap[" + i + "].soluong";
    inp2.min = 1;
    inp2.onchange = sluong_ct;
    inp2.value = document.getElementById("_sluong").value;
    col2.appendChild(inp2);
    row.appendChild(col2);
    ///create input gia
    var col3 = document.createElement("td");
    var inp3 = document.createElement("input");
    inp3.type = "text";
    inp3.name = "ctphieunhap[" + i + "].gia";
    inp3.id = "ctphieunhap[" + i + "].gia";
    inp3.readOnly = true;
    inp3.value = document.getElementById("_gia").value;
    ///sach.gia
    col3.appendChild(inp3);
    row.appendChild(col3);
    ///create input thanhtien
    var col4 = document.createElement("td");
    var inp4 = document.createElement("input");
    inp4.type = "text";
    inp4.name = "ctphieunhap[" + i + "].thanhtien";
    inp4.id = "ctphieunhap[" + i + "].thanhtien";
    inp4.readOnly = true;
    inp4.value = Number(inp2.value) * Number(inp3.value);
    col4.appendChild(inp4);
    row.appendChild(col4);
    ///create input delete
    var col5 = document.createElement("td");
    var inp5 = document.createElement("a");
    inp5.text = "Xóa";
    inp5.href = "javascript:xoactphieunhap(" + i + ")";
    col5.appendChild(inp5);
    row.appendChild(col5);
    document.getElementById("ds-sach").appendChild(row);
    ////tong tien
    var tongtien = Number(document.getElementById("phieunhap.tongtien").value);
    tongtien += Number(inp4.value);
    document.getElementById("phieunhap.tongtien").value = tongtien;
    document.getElementById("nxb.tonkho").value = tongtien;
}
function checkctphieunhap()
{
    ////alert(new String("").valueOf());
    //if ((document.getElementById("masach").value.replace(/\s/g, "") == new String("").valueOf()) || (document.getElementById("masach").value == null))
    //{
    //    alert("Vui lòng nhập mã sách !");
    //    return false;
    //}
    //if ((document.getElementById("tensach").value.replace(/\s/g, "") == new String("").valueOf()) || (document.getElementById("tensach").value == null)) {
       // alert("Vui lòng nhập tên sách!");
        //return false;
    //}
    var _masach = document.getElementById("_masach");
    var selectedValue = _masach.options[_masach.selectedIndex].value;
    if (selectedValue == '') {
        alert("Vui lòng chọn sách !");
        return false;
    }
    if ((document.getElementById("_sluong").value == null) || (Number(document.getElementById("_sluong").value) <= 0)) {
        alert("Số lượng không hợp lệ!");
        return false;
    }
    if ((document.getElementById("_gia").value == null) || (Number(document.getElementById("_gia").value) <= 0)) {
        alert("Giá không hợp lệ!");
        return false;
    }
    return true;
}
function xoactphieunhap(i) {
    var tongtien = Number(document.getElementById("phieunhap.tongtien").value);
    tongtien -= Number(document.getElementById("ctphieunhap["+i+"].thanhtien").value);
    document.getElementById("phieunhap.tongtien").value = tongtien;
    document.getElementById("nxb.tonkho").value = document.getElementById("phieunhap.tongtien").value;
    var node = document.getElementById("ctphieunhap[" + i + "]");
    //alert(node);
    node.parentNode.removeChild(node);
}
function manxb()
{
    var value = document.getElementById("nxb.manxb").value;
    var manxb = document.getElementById("phieunhap.manxb");
    manxb.value = value;
}
function madl() {
    var value = document.getElementById("daily.madl").value;
    var manxb = document.getElementById("phieuxuat.madl");
    manxb.value = value;
}
function sluong_ct()
{
//    alert(i);
        var tongtien = 0;
        for (var j = 0; j < document.getElementsByClassName("ctphieunhapIndex").length; j++) {

        var r = document.getElementsByClassName("ctphieunhapIndex")[j].value;
        //alert(r);
        var num = Number(document.getElementById("ctphieunhap[" + r + "].soluong").value);
        //document.getElementById("sach[" + r + "].sluong").value = num;
        document.getElementById("ctphieunhap[" + r + "].thanhtien").value =
                        Number(document.getElementById("ctphieunhap[" + r + "].soluong").value) * Number(document.getElementById("ctphieunhap[" + r + "].gia").value);

        tongtien += Number(document.getElementById("ctphieunhap[" + r + "].thanhtien").value);
    }
    document.getElementById("phieunhap.tongtien").value = tongtien;
    document.getElementById("nxb.tonkho").value = document.getElementById("phieunhap.tongtien").value;
}
function themctphieuxuat() {
    ///themctphieuxuat
    if (!checkctphieuxuat())
        return false;
    var sach = document.getElementById("_masach").value.split("|");
    var masach = sach[0];
    var maphieunhap = sach[1];
    if (document.getElementsByClassName("ctphieuxuatIndex").length > 0) {
        //alert(document.getElementsByClassName("sachIndex").length);
        for (var j = 0; j < document.getElementsByClassName("ctphieuxuatIndex").length; j++) {
            var r = document.getElementsByClassName("ctphieuxuatIndex")[j].value;
            ////alert(r);
            if (document.getElementById("ctphieuxuat[" + r + "].masach").value == masach) {
                alert("Thông tin sách đã tồn tại!");
                return false;
            }
        }
    }
    i++;
    var row = document.createElement("tr");
    row.id = "ctphieuxuat[" + i + "]";
    var col = document.createElement("td");
    ///create input masach
    var col1 = document.createElement("td");
    var inp1 = document.createElement("input");
    inp1.type = "text";
    inp1.name = "ctphieuxuat[" + i + "].masach";
    inp1.id = "ctphieuxuat[" + i + "].masach";
    inp1.readOnly = true;
    inp1.value = masach;
    ///ctphieuxuat.mapn
    var inpms = document.createElement("input");
    inpms.type = "hidden";
    inpms.name = "ctphieuxuat[" + i + "].maso";
    inpms.id = "ctphieuxuat[" + i + "].maso";
    inpms.value = document.getElementById("phieuxuat.maso").value;
    ///ctphieunhap
    var inpn = document.createElement("input");
    inpn.type = "hidden";
    inpn.name = "ctphieuxuat[" + i + "].maphieunhap";
    inpn.id = "ctphieuxuat[" + i + "].maphieunhap";
    inpn.value = maphieunhap;
    ///index sach
    var inpIds = document.createElement("input");
    inpIds.type = "hidden";
    inpIds.name = "ctphieuxuat.Index";
    inpIds.id = "ctphieuxuat.Index";
    inpIds.className = "ctphieuxuatIndex";
    inpIds.value = i;
    ///append
    col1.appendChild(inp1);
    col1.appendChild(inpms);
    col1.appendChild(inpn);
    col1.appendChild(inpIds);
    row.appendChild(col1);
    ///create input sluong
    var col2 = document.createElement("td");
    var inp2 = document.createElement("input");
    inp2.type = "number";
    inp2.name = "ctphieuxuat[" + i + "].soluong";
    inp2.id = "ctphieuxuat[" + i + "].soluong";
    inp2.min = 1;
    inp2.max = $('#sluong').attr('max');
    inp2.onchange = sluong_ctx;
    inp2.value = document.getElementById("sluong").value;
     col2.appendChild(inp2);
    row.appendChild(col2);
    ///create input gia
    var col3 = document.createElement("td");
    var inp3 = document.createElement("input");
    inp3.type = "text";
    inp3.name = "ctphieuxuat[" + i + "].gia";
    inp3.id = "ctphieuxuat[" + i + "].gia";
    inp3.readOnly = true;
    inp3.value = document.getElementById("gia").value;
    ///sach.gia
    col3.appendChild(inp3);
    row.appendChild(col3);
    ///create input thanhtien
    var col4 = document.createElement("td");
    var inp4 = document.createElement("input");
    inp4.type = "text";
    inp4.name = "ctphieuxuat[" + i + "].thanhtien";
    inp4.id = "ctphieuxuat[" + i + "].thanhtien";
    inp4.readOnly = true;
    inp4.value = Number(inp2.value) * Number(inp3.value);
    col4.appendChild(inp4);
    row.appendChild(col4);
    ///create input delete
    var col5 = document.createElement("td");
    var inp5 = document.createElement("a");
    inp5.text = "Xóa";
    inp5.href = "javascript:xoactphieuxuat(" + i + ")";
    col5.appendChild(inp5);
    row.appendChild(col5);
    document.getElementById("ds-sach").appendChild(row);
    ////tong tien
    var tongtien = Number(document.getElementById("phieuxuat.tongtien").value);
    tongtien += Number(inp4.value);
    document.getElementById("phieuxuat.tongtien").value = tongtien;
    document.getElementById("daily.tonkho").value = tongtien;
}
function checkctphieuxuat() {
    ////alert(new String("").valueOf());
    var _masach = document.getElementById("_masach");
    var selectedValue = _masach.options[_masach.selectedIndex].value;
    if (selectedValue == '') {
        alert("Vui lòng chọn sách !");
        return false;
    }
    if ((document.getElementById("sluong").value == null) || (Number(document.getElementById("sluong").value) <= 0) || (Number($('#sluong').val()) > (Number($('#sluong').attr('max'))))) {
        alert("Số lượng không hợp lệ! Số lượng phải nhỏ hơn "+ $('#sluong').attr('max')+"!");
        return false;
    }
    if ((document.getElementById("gia").value == null) || (Number(document.getElementById("gia").value) <= 0) || (Number($('#gia').val()) < (Number($('#gia').attr('min'))))) {
        alert("Giá không hợp lệ! Giá phải lớn hơn " + $('#gia').attr('min') + "!");
        return false;
    }
    return true;
}
function sluong_ctx()
{
    //    alert(i);
    var tongtien = 0;
    for (var j = 0; j < document.getElementsByClassName("ctphieuxuatIndex").length; j++) {

        var r = document.getElementsByClassName("ctphieuxuatIndex")[j].value;
    //    alert(r);
        var num = Number(document.getElementById("ctphieuxuat[" + r + "].soluong").value);
        document.getElementById("ctphieuxuat[" + r + "].thanhtien").value =
                        Number(document.getElementById("ctphieuxuat[" + r + "].soluong").value) * Number(document.getElementById("ctphieuxuat[" + r + "].gia").value);

        tongtien += Number(document.getElementById("ctphieuxuat[" + r + "].thanhtien").value);
    }
    document.getElementById("phieuxuat.tongtien").value = tongtien;
    document.getElementById("daily.tonkho").value = document.getElementById("phieuxuat.tongtien").value;
}
function xoactphieuxuat(i) {
    var tongtien = Number(document.getElementById("phieuxuat.tongtien").value);
    tongtien -= Number(document.getElementById("ctphieuxuat[" + i + "].thanhtien").value);
    document.getElementById("phieuxuat.tongtien").value = tongtien;
    document.getElementById("daily.tonkho").value = document.getElementById("phieuxuat.tongtien").value;
    var node = document.getElementById("ctphieuxuat[" + i + "]");
    //alert(node);
    node.parentNode.removeChild(node);
}