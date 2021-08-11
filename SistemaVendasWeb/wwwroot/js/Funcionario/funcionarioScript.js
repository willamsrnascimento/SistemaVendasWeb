function excluirFuncionarioModal(id, nome) {
    $("#titulo-modal")[0].innerHTML = "Exclusão de funcionários"
    $("#corpo-modal")[0].innerHTML = "Tem certeza que deseja excluir o(a) funcionário(a) " + nome + "?"
    $("#idFuncionario").val(id)
}

$('document').ready(function () {
    $(".input-imagem").change(function (event) {
        var link = URL.createObjectURL(event.target.files[0]);
        $(".imagem-mostrar").attr('src', link)
    })
});


    
