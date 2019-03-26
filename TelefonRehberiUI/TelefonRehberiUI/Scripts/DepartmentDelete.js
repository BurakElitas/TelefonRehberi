$(function () {

    $(".btnSil").click(function () {

        var id = $(this).data("department-id");
        var tr = "#tr_" + id;
        $.ajax({
            method: "POST",
            url: "/Department/Delete/" + id,
        }).done(function (data) {
            if (!data.result) {
                alert(data.error);
            }
            else {
                $("#deleting").show(300, function () {

                    $(tr).remove();
                });
            }
        }).always(function () {

            $("#deleting").hide(400);
        });

    });

});