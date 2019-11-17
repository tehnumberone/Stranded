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
$(".Tile").click(function() {
    $(this).prev('img').src("~/images/CharModels/"+$(this).data("model"));
});