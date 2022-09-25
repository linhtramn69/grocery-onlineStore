$(function () {

})
$(document).ready(function () {
    $(".new").click(function () {
        if($('#namemodal').html() !== "Thêm sản phẩm"){
           location.reload(); 
        }
        })
  $('#add').click(function(){
    $("tbody tr:first-child").before(
      '<tr><td><input type="checkbox" name="" id=""></td><td>' +
        $("#tsp").val() +
        "</td><td>" +
        $("#lsp").val() +
        '</td><td><img width="100px" src="image/' +
        $("#img").val().replace(/C:\\fakepath\\/i, '') +
        '" alt=""></td><td><input type="checkbox" name="" id=""></td><td><input type="checkbox" checked name="" id=""></td><td><a href=""><i class="text-danger fas fa-edit"></i></a><a href=""><i class="ms-3 text-danger fas fa-times"></i></a></td></tr>'
        
    );
  });
  $('.remove').click(function() {
      $(this).parent().parent().remove();
      $(window).unload();
  });
  $('.edit').click(function() {
      $('#msp').val($(this).parent().parent().attr("id"));
      $('#tsp').val($($(this).parent().parent().children()[1]).html())
      $('#lsp').after('<input type="text" class="form-control" id="lsp" value="'+$($(this).parent().parent().children()[2]).html()+'">');
      $('#lsp').remove();
      $("#add").html("Cập nhật")
      $('#namemodal').html("Sửa thông tin sản phẩm");
  });

});
