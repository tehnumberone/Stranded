$(function () {
    $(".Char").click(
        function () {
            SetCharId("#CharModelInput", $(this).data("model"));
        }
    );
});

function SetCharId(charId, charModelString) {
    $(charId).val(charModelString);
}
$(function () {
    $(".Tile").click(function () {
        var oldtd;
        oldtd = this;
        $(this).attr('src', "../images/CharModels/" + $(this).data("model"));
        $(oldtd).prev.attr('src', "../images/Map/grass.jpg");
    });
});