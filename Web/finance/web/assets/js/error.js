$(function () {
    var code = getUrlParam('code');
    var msg = getUrlParam('msg');
    $('#msg').text = msg;
    $('title').val(code)
})

