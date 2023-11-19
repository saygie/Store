$(document).ready(function () {
    var todo;
    var inprogress;
    var completed;
    var requestData;
    $("#todo, #inprogress, #completed").sortable({
        connectWith: ".connectList",
        update: function (event, ui) {

            todo = $("#todo").sortable("toArray");
            inprogress = $("#inprogress").sortable("toArray");
            completed = $("#completed").sortable("toArray");
            requestData = {
                Yapilacak: todo,
                DevamEden: inprogress,
                Tamamlanan: completed,
            };
            $.ajax({
                url: '/Is/Takip',
                type: 'POST',
                data: JSON.stringify(requestData),
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                error: function (xhr) {
                    alert('Errorrr: ' + xhr.statusText);
                },
                success: function (result) {
                    alert('TAMAM: ' + xhr.statusText);
                },
                //async: true,
                //processData: false
            });
            $('.output').html("ToDo: " + window.JSON.stringify(todo) + "<br/>" + "In Progress: " + window.JSON.stringify(inprogress) + "<br/>" + "Completed: " + window.JSON.stringify(completed));
        }
    }).disableSelection();

});