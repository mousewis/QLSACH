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
            ////alert(request);
            if (!request.length) return;
            $('#sluong').attr('readonly','readonly');
            $.ajax({
                url: '/Home/Sach_Max',
                data: { masach: request },
                dataType: "json",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                success: function (results) {
                    ////alert(results);
                    $('#sluong').removeAttr('readonly');
                    $('#sluong').attr('max', results);
                    return results;
                },
                error: function () {
                    $('#sluong').attr('max', "1");
                }
            });
        }
    });
});