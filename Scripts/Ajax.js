$(function () {
    $(".del-btn").click(function () {
        if (confirm("Are you sure you want to delete this product?")) {
            var element = $(this);
            var del_id = element.attr("id");
            var info = "id=" + del_id;
            $.ajax({
                type: "POST",
                url: "/Products/Delete",
                data: info,
                success: function (data) {
                    if (data) {
                        $("#productCard" + del_id).fadeOut();
                    } else {
                        alert("Record can't be deleted!");
                    }
                }
            });
        }
        return false;
    });
});