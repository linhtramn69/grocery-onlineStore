var itemList = {
  sp001: {
    name: "Tương ớt tròn 5 vị cay đậm Knorr",
    price: 10000,
    img: "image/Khuyenmai/tuong-ot-tron-5-vi-cay-dam-knorr.jpg",
  },
  sp002: {
    name: "Nước giặt Surf hương nước hoa",
    price: 94500,
    img: "image/Khuyenmai/nuoc-giat-surf-huong-nuoc-hoa-tui-3-lit.jpg",
  },
  sp003: {
    name: "Gel tắm dưỡng ẩm Fresh Organic",
    price: 71500,
    img: "image/Khuyenmai/gel-tam-duong-am.jpg",
  },
  sp004: {
    name: "Nước ngọt Mirinda đá me",
    price: 54000,
    img: "image/Khuyenmai/loc-6-lon-nuoc-ngot-mirinda-da-me.jpg",
  },
  sp005: {
    name: "Nước ngọt Pepsi không calo",
    price: 54000,
    img: "image/Khuyenmai/loc-6-lon-nuoc-ngot-pepsi-khong-calo.jpg",
  },
  sp006: {
    name: "Trà ô long Tea Plus vị chanh",
    price: 40000,
    img: "image/Khuyenmai/6-chai-tra-o-long-tea-plus-vi-chanh.jpg",
  },
};

$(document).ready(function () {
  var sum = 0;
  $.each(window.localStorage, function (key, value) {
    if (itemList[key] === undefined) {
      return;
    }
    btn =
      "<td><div class='d-grid gap-2'><button class='btn btn-success btn-lg' onclick='remove(\"" +
      key +
      "\");'><i class='far fa-trash-alt'></i></button></div></td>";
    $("#tbody").append(
      "<tr id='" +
        key +
        "'><td><input type='checkbox' class='check' checked></td><td><img src='" +
        itemList[key].img +
        "' width='150px'></td><td>" +
        itemList[key].name +
        "</td><td>" +
        localStorage.getItem(key) +
        "</td><td class='price'>" +
        Intl.NumberFormat().format(
          parseInt(itemList[key].price * parseInt(value))
        ) +
        " đ" +
        "</td>" +
        btn +
        "</tr>"
    );
    sum += itemList[key].price * parseInt(value);
  });
  var ship = 0;
  var buy = 200000
  if(sum<200000 && sum >0){
    ship = 15000;
    buy=200000-sum;
  }else{buy=0}
  $('#ship').html(Intl.NumberFormat().format(ship) +"đ");
  $("#sum").html(Intl.NumberFormat().format(sum + ship) + "đ");
  $("#bill").html(Intl.NumberFormat().format(sum + ship) + "đ");
  $("#billSuccess").html(Intl.NumberFormat().format(sum + ship) + "đ");

  $("#buy").html(Intl.NumberFormat().format(buy));
});
function remove(key) {
  localStorage.removeItem(key);
  location.reload();
}
window.onstorage = () => {
  location.reload();
};
