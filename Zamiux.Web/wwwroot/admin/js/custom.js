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
            $('#filter-form').submit();
        } 
    });
}

// delete ajax record user ability
function deleteuserability(UserAblityId) {
    // url : /Admin/UserInfo/Delete_User_Intro/ + UserintroId
    $.get('/Admin/UserInfo/Delete_User_Ability/' + UserAblityId).then(res => {
        if (res.status === 'success') {
            $('#ability_' + UserAblityId).fadeOut();
            $('#filter-form').submit();
        }
    });
}

// delete ajax record user social
function deleteusersocial(UserSocialId) {
    // url : /Admin/UserInfo/Delete_User_Intro/ + UserintroId
    $.get('/Admin/UserInfo/Delete_User_Social/' + UserSocialId).then(res => {
        if (res.status === 'success') {
            $('#userintro_' + UserSocialId).fadeOut();
            $('#filter-form').submit();
        }
    });
}


// delete ajax record user service
function deleteuserservice(UserServiceId) {
    // url : /Admin/UserInfo/Delete_User_Service/ + UserintroId
    $.get('/Admin/UserService/Delete_User_Service/' + UserServiceId).then(res => {
        if (res.status === 'success') {
            $('#ability_' + UserServiceId).fadeOut();
            $('#filter-form').submit();
        }
    });
}

// Contact_Message

function deleteusermsg(UserMsgId) {
    // url : /Admin/UserInfo/Delete_User_Service/ + UserintroId
    $.get('/Admin/Home/Delete_Message/' + UserMsgId).then(res => {
        if (res.status === 'success') {
            $('#msg_' + UserMsgId).fadeOut();
            $('#filter-form').submit();
        }
    });
}
