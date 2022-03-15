var showDeleteConfirmation = function (ItemId) {
    $("#confirmationModal").modal('show');
    $("#hiddenItemId").val(ItemId);
};

var deleteItem = function (link) {
    var id = $("#hiddenItemId").val();
    $.ajax({
        type: "POST",
        url: link,
        data: { Id: id },
        success: function (result) {
            location.reload();
        }
    });
    $("#confirmationModal").modal("hide");
}
