$(".btnEditar").click(function () {
    var url = "/Home/Editar"; // url del controller
    var id = $(this).attr("data-id"); // parametro  
    $.get(url + '/' + id, function (data) {
        alert(data); //retorna la vista (html)
        $(".edit-person-container").html(data);
        $(".edit-person").modal('show');
    });
});