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

function toggleDropdown(e) {
    const _d = $(e.target).closest('.dropdown'),
        _m = $('.dropdown-menu', _d);
    setTimeout(function () {
        const shouldOpen = e.type !== 'click' && _d.is(':hover');
        _m.toggleClass('show', shouldOpen);
        _d.toggleClass('show', shouldOpen);
        $('[data-toggle="dropdown"]', _d).attr('aria-expanded', shouldOpen);
    }, e.type === 'mouseleave' ? 100 : 0);
}

$(document).ready(function () {
    loadChar();
});

$('body')
    .on('mouseenter mouseleave', '.dropdown', toggleDropdown)
    .on('click', '.dropdown-menu a', toggleDropdown);

function saveGame() {
    if (window.Level !== undefined && window.characterID !== undefined ) {
        var charData = {
            inventoryItems: "'" + window.InventoryItems + "'",
            hp: window.HP,
            level: window.Level,
            hunger: window.Hunger,
            hydration: window.Hydration,
            characterID: window.characterID
        };
        console.log(charData);
        $.ajax({
            type: 'POST',
            data: charData,
            url: '/Map/SaveGame',
            success: alert('Progress saved. You can now leave this page safely.')
        });
    }
}