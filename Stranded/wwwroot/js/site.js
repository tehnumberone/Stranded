$(function () {
    $(".Char").click(
        function() {
            SetCharId("#CharModelInput", $(this).data("model"));
        }
    );
});

function SetCharId(charId, charModelString) {
    $(charId).val(charModelString);
}