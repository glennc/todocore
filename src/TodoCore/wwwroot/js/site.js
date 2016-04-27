
function checkCheckbox(id) {
    $("#checkbox" + id).trigger('click');
}

var _loop = function _loop(i) {
    key = 'alt+' + i % 10;

    Mousetrap.bind(key, function (e) {
        checkCheckbox(i);
    });
};

for (var i = 1; i <= 10; i++) {
    var key;

    _loop(i);
}