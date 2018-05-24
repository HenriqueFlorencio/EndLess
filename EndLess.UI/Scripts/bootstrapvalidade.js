$.validator.setDefaults({
    highlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').find("input,label,select,textarea,span").addClass('is-invalid');
    },
    unhighlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').find("input,label,select,textarea,span").removeClass('is-invalid');
    }
});