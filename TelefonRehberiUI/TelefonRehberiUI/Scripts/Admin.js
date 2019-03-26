$(function () {

    $(".btnSil").click(function () {

        var answer = confirm("Bu admini silmek istediğinizden emin misiniz?");
        if (answer == true) {
            var id = $(this).data("admin-id");
            var tr = "#tr_" + id;
            $.ajax({
                method: "POST",
                url: "/Admin/Delete/" + id,
            }).done(function (data) {
                if (data.result) {
                    $("#deleting").show(300, function () {

                        $(tr).remove();
                    });
                }
            }).always(function () {

                $("#deleting").hide(400);
            });
        }
    });
});