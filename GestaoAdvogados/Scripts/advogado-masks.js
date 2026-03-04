// Aplicar máscaras aos campos
$(document).ready(function () {
    // Máscara para CEP (00000-000)
    $('.cep-mask').mask('00000-000');

    // Máscara para número (apenas dígitos)
    $('.numero-mask').mask('0#');
});
