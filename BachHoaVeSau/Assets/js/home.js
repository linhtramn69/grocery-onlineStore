$(document).ready(function () {
  $('#search').keypress(function(event){
    var keycode = (event.keyCode ? event.keyCode : event.which);
    if (keycode == '13') {
        if($(this).val().length != 0) {
            click();
        }
    }
    });
  $('#btnsearch').click(function(event){
    if($('#search').val().length == 0) {
      alert('Vui lòng nhập nội dung cần tìm')
    }
  });
  if(localStorage.getItem('login')=='on'){
    $('#onlogin').css('display','block');
    $('#offlogin').css('display','none');
    $(".count").html(localStorage.length-1);
  }
  $('#signout').click(function(){
    $('#onlogin').css('display','none');
    $('#offlogin').css('display','block');
    localStorage.removeItem('login');
    location.reload();
  })
});

function addCard(id) {
  var current = parseInt(window.localStorage.getItem(id));
  if (typeof localStorage[id] === "undefined") {
    window.localStorage.setItem(id, "1");
  } else {
    window.localStorage.setItem(id, (current += 1));
  }
  location.reload();
}

