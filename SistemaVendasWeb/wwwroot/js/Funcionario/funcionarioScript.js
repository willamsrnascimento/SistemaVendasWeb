function excluirFuncionarioModal(id, nome) {
    var token

    $("#titulo-modal")[0].innerHTML = "Exclusão de funcionários"
    $("#corpo-modal")[0].innerHTML = "Tem certeza que deseja excluir o(a) funcionário(a) " + nome + "?"

    $("#excluir-modal").on("click", function () {
        token = $('input[name="__RequestVerificationToken"]').val();
        $.ajax({
            type: "DELETE",
            url: "Funcionario/Excluir",
            data: {
                __RequestVerificationToken: token,
                id: id
            },
            success: function (data) {
                console.log(data);
                location.reload(true)
            }
        });
    });

}