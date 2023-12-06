// file upload preview in image box 
$("[ImageInput]").change(function () {
    var x = $(this).attr("ImageInput");
    if (this.files && this.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("[ImageFile=" + x + "]").attr('src', e.target.result);
        };
        reader.readAsDataURL(this.files[0]);
    }
});


// delete ajax record user intro
function deleteuserintro(UserintroId) {
    // url : /Admin/UserInfo/Delete_User_Intro/ + UserintroId
    $.get('/Admin/UserInfo/Delete_User_Intro/' + UserintroId).then(res => {
        if(res.status === 'success'){
            $('#userintro_' + UserintroId).fadeOut();
        } 
    });
}

// delete ajax record user ability
function deleteuserability(UserAblityId) {
    // url : /Admin/UserInfo/Delete_User_Intro/ + UserintroId
    $.get('/Admin/UserInfo/Delete_User_Ability/' + UserAblityId).then(res => {
        if (res.status === 'success') {
            $('#ability_' + UserAblityId).fadeOut();
        }
    });
}