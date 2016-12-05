$(document).ready(function () {
    $('#_masach').selectize({
        create: false,
        valueField: 'masach',
        labelField: 'tensach',
        searchField: ['masach', 'tensach'],
        
        render: {
            item: function (item, escape) {
                var name = item;
                return '<div>' +
                    (item.masach ? '<span class="masach">' + escape(item.masach) + '</span>' : '') + ' - '
                    + (name ? '<span class="tensach">' + escape(item.tensach) + '</span>' : '') +
                '</div>';
            },
            option: function (item, escape) {
                var name = item;
                return '<div>' +
                    '<span class="label">' + escape(item.masach) + '</span>' +
                    (name ? '<span class="caption">' + escape(item.tensach) + '</span>' : '') +
                '</div>';
            }
        },
        onChange: function (request) {

            //alert(request);
            if (!request.length) return;
            var _request = request.split("|");
            var _masach = _request[0];
            var _maphieunhap = _request[1];
            $('#sluong').attr('readonly','readonly');
            $('#gia').attr('readonly', 'readonly');
            $.ajax({
                url: '/Home/Sach_Max',
                data: { masach:_masach },
                dataType: "json",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                success: function (results) {
                    ////alert(results);
                    $('#sluong').removeAttr('readonly');
                    $('#sluong').attr('max', results);
                    $('#sluong').val(results);
                    return results;
                },
                error: function () {
                    $('#sluong').attr('max', "1");
                }
            });
            $.ajax({
                url: '/Home/Gia_Min',
                data: { masach: _masach, maphieunhap: _maphieunhap },
                dataType: "json",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                success: function (results) {
                    ////alert(results);
                    $('#gia').removeAttr('readonly');
                    $('#gia').attr('min', results);
                    $('#gia').val(results);
                    return results;
                },
                error: function () {
                    $('#gia').attr('min', "0");
                }
            });
        }
    });
});