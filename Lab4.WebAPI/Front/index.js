
    const newLocal = $(document).ready(function() {
    var modal = $('#modal');
    var user = $('#userHi');
    var userResult = $('#StatisticrResult');

        var currentUser ;

    $('#btn').click(function() {
        var username = $('#txtUsername').val();
        var password = $('#txtPassword').val();
        var ap = 2;

        $.ajax({
            type: 'GET',
            url: "api/Users?login=" + username,
            dataType: 'json',
            headers: {
                'Authorization': 'Basic ' + btoa(username + ':' + password)
            },
            success: function (data) {
                user = data;
                $(document.body).empty();
                $.get('Front/cabinet.html', html => {
                    $(document.body).html(html);
                    $('#userHi').append('Вітаємо, ' + data.fullName);
                    afterLoad();
                })
            },
            complete: function(jqXHR) {
                if (jqXHR.status !== 200) {
                    modal.css("display", "block");
                    setTimeout( () => {
                        modal.css("display", "none");
                    }, 5000 )
                }
            }
        });
    });

    const afterLoad = () => {
        var username = user.login;

        $.ajax({
            type: 'GET',
            url: "api/Cards?login=" + username,
            dataType: 'json',
            success: function (data) {
                $('#selecter').empty();
                $.each(data, function (index, val) {
                    var number = val.number;
                    var cardId = val.id;
                    $('#selecter').append('<option value=' + String(cardId) + '>' + number + '</option>');
                });
            },
            complete: function (jqXHR) {
                if (jqXHR.status == '401') {
                    $('#selecter').empty();
                    ulTrain.append('<li style="color:red">' + jqXHR.status + ' : ' + jqXHR.statusText + '</li>');
                }
            }
        });
    };

});