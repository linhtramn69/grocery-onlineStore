// SIGN UP
function error(id) {
  id.classList.add("is-invalid");
}
function accept(id) {
  id.classList.remove("is-invalid");
  id.classList.add("is-valid");
}
function frmValidate() {
  /***Name***/
  var fn = document.getElementById("FirtName");
  if (fn.value.length == 0) {
    error(fn);
  }
  var ln = document.getElementById("LastName");
  if (ln.value.length == 0) {
    error(ln);
  }
  /****Số điện thoại***/
  var s = document.getElementById("SDT");
  if (s.value.length == 0) {
    error(s);
  }
  /***Email****/
  var mail = document.getElementById("Email");
  if (mail.value.length == 0) {
    error(mail);
  }
  /***Password***/
  var p = document.getElementById("Password");
  if (p.value.length == 0) {
    error(p);
  }
  var repas = document.getElementById("RePassword");
  if (repas.value != p.value) {
    error(repas);
    return false;
  }
  if (repas.value.length == 0) {
    error(repas);
    return false;
  }

  alert("Đăng ký thành công");
  return true;
}
function checkmail(id) {
  var val = document.getElementById(id);
  var filter =
    /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
  if (!filter.test(val.value)) {
    error(val);
    return false;
  }
  accept(val);
}
function checkpass(id) {
  var val = document.getElementById(id);
  var reg = new RegExp(
    "^(?=.*[A-z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{8})"
  );
  if (!reg.test(val.value)) {
    error(val);
    return false;
  }
  accept(val);
}
function checksdt(id) {
  var val = document.getElementById(id);
  var reg = /^([0-9])/;
  if (!reg.test(val.value) || val.value.length != 10) {
    error(val);
    return false;
  }
  accept(val);
}
function checkname(id) {
  var val = document.getElementById(id);
  if (val.value.length == 0) {
    error(val);
    return false;
  }
  accept(val);
}
function checkrepass(id) {
  var val = document.getElementById(id);
  var p = document.getElementById("Password");
  if (val.value != p.value) {
    error(val);
    return false;
  }
  accept(val);
};
// LOGIN
function frmJson() {
  var s = document.getElementById('SDT');
  var p = document.getElementById('Password');
  var json = '{"SDT": ["0901910467", "0901910402", "admin"], "Password": ["467", "402","admin"]}';
  var obj = JSON.parse(json);
  for (var i = 0; i < obj.SDT.length; i++) {
      if (s.value == obj.SDT[i]) {
          if (p.value == obj.Password[i]){
            if(s.value =="admin"){
              var at = document.createAttribute('action');
              at.value = "admin.html";
              document.getElementById('login').setAttributeNode(at);
            }
            else{
              var at = document.createAttribute('action');
              at.value = "TrangChu.html";
              document.getElementById('login').setAttributeNode(at);
            }
            localStorage.setItem('login','on');
            return true;
          }
      }
  }
  alert('Tài khoản hoặc mật khẩu không đúng');
  return false;
}


