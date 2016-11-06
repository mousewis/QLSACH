$(document).ready(function () {
    $("input[name='nxb.manxb']").autocomplete({
        //source: function( request, response ) {
        //    var array = $.map(array_nxbs, function (item) {
        //        var code = item.split("|");
        //        return {
        //            label: code[0],
        //            value: code[0],
        //            data : item
        //        }
        //    });
        //    //call the filter here
        //    response($.ui.autocomplete.filter(array, request.term));
        //},
        source: function (request, response) {
            $.ajax({
                url: '/Home/Nxbs',
                data: { manxb: request.term },
                dataType: "json",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        var code = item.split("|");
                        return {
                            label: code[0],
                            value: code[0],
                            data: item
                        }
                    }));
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        autoFocus: true,
        minLength: 1,
        select: function (event, ui) {
            var names = ui.item.data.split("|");
            $("input[name='phieunhap.manxb']").val(names[0]);
            $("input[name='nxb.tennxb']").val(names[1]);
            $("input[name='nxb.sdt']").val(names[2]);
            $("input[name='nxb.dchi']").val(names[3]);
        }
    });
     $("input[name='daily.madl']").autocomplete({
        //source: function( request, response ) {
        //    var array = $.map(array_dls, function (item) {
        //        var code = item.split("|");
        //        return {
        //            label: code[0],
        //            value: code[0],
        //            data : item
        //        }
        //    });
        //    //call the filter here
        //    response($.ui.autocomplete.filter(array, request.term));
        //},
        source: function (request, response) {
            $.ajax({
                url: '/Home/Dailies',
                data: { madl: request.term },
                dataType: "json",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        var code = item.split("|");
                        return {
                            label: code[0],
                            value: code[0],
                            data: item
                        }
                    }));
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        autoFocus: true,
        minLength: 1,
        select: function (event, ui) {
            var names = ui.item.data.split("|");
            $("input[name='phieuxuat.madl']").val(names[0]);
            $("input[name='daily.tendl']").val(names[1]);
            $("input[name='daily.sdt']").val(names[2]);
            $("input[name='daily.dchi']").val(names[3]);
        }
     });
     $("input[name='masach']").autocomplete({
         //source: function( request, response ) {
         //    var array = $.map(array_sachs, function (item) {
         //        var code = item.split("|");
         //        return {
         //            label: code[0],
         //            value: code[0],
         //            data : item
         //        }
         //    });
         //    //call the filter here
         //    response($.ui.autocomplete.filter(array, request.term));
         //},
         source: function (request, response) {
             $.ajax({
                 url: '/Home/sachs',
                 data: { masach: request.term },
                 dataType: "json",
                 type: "GET",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     response($.map(data, function (item) {
                         var code = item.split("|");
                         return {
                             label: code[0],
                             value: code[0],
                             data: item
                         }
                     }));
                 },
                 error: function (response) {
                     alert(response.responseText);
                 },
                 failure: function (response) {
                     alert(response.responseText);
                 }
             });
         },
         autoFocus: true,
         minLength: 1,
         select: function (event, ui) {
             var names = ui.item.data.split("|");
             $("input[name='tensach']").val(names[1]);
             $("#linhvuc").val(names[2]).change();
         }
     });
});