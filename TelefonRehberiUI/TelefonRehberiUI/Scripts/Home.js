$(function () {
    $('#details').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var pid = $(button).data("personel-id");
        $("#details_body").load("/Home/Details/" + pid);

    });

    $(".btnSil").click(function () {

        var id = $(this).data("personel-id");
        var tr = "#tr_" + id;
        $.ajax({
            method: "POST",
            url: "/Home/Delete/" + id,
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