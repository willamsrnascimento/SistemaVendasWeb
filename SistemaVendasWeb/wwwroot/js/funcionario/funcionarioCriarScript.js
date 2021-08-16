$('document').ready(function () {
    $(".input-imagem").change(function (event) {
        var link = URL.createObjectURL(event.target.files[0]);
        $(".imagem-mostrar").attr('src', link)
    })

    var resposta = $("#id-funcionario").val();
    if (resposta != "" && resposta != 0) {
        $("#botao-cria-funcionario").attr('disabled', 'disabled');
        $(".form-control").attr('readonly', 'readonly');
        $(".input-imagem").attr('disabled', 'disabled');
    } else {        
        $("#botao-adicionar-endereco-funcionario").attr('disabled', 'disabled');
    }

});
