$(document).ready(function () {
    $("#cpf").mask("000.000.000-00")

    $("#rg").mask("0.000.000")

    $("#telefone").focus(function (event) {
        $("#telefone").mask("(00) 0000-00009")
    })

    $("#telefone").blur(function (event) {
        if ($(this).val().length == 15) {
            $("#telefone").mask("(00) 00000-0009")
        } else {
            $("#telefone").mask("(00) 0000-0000")
        }
    })

    $("#cep").mask("00.000-000")
})