
var imageindex = 1;
tabs(imageindex);

// Next/previous controls
function plusImages(n) {
  tabs((imageindex += n));
}

// Thumbnail image controls
function currentImages(n) {
  tabs((imageindex = n));
}

function tabs(n) {
  var i;
  var items = document.querySelectorAll(".item");
  var contents = document.querySelectorAll(".img-main");

  if (n > items.length) {
    imageindex = 1;
  }
  if (n < 1) {
    imageindex = items.length;
  }
  for (i = 0; i < items.length; i++) {
    items[i].classList.remove("active-img");
    contents[i].classList.remove("active-img");
  }
  contents[imageindex - 1].classList.add("active-img");
  items[imageindex - 1].classList.add("active-img");
}
setInterval(function () {
  tabs((imageindex += 1));
}, 30000);


