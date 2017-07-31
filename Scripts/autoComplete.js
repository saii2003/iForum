function autoComplete(){
    $(function () {
        $("#ContentPlaceHolder1_search").autocomplete({
            source: function (request, response) {
                var param = { articletitle: $('#ContentPlaceHolder1_search').val() };
                $.ajax({
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    type: "post",
                    url: "../MemberWebService.asmx/getSearchTitle",
                    data: JSON.stringify(param),
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                value: item
                            }
                        }))

                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    minLength: 1 //至少輸入1字元

                });
            },
        });
    });
}