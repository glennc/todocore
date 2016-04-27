function checkCheckbox(id) {
    $("#checkbox"+id).trigger('click');
}

Mousetrap.bind('ctrl+1', function(e) {
    checkCheckbox(1);
});
Mousetrap.bind('ctrl+2', function(e) {
    checkCheckbox(2);
});
Mousetrap.bind('ctrl+3', function(e) {
    checkCheckbox(3);
});
Mousetrap.bind('ctrl+4', function(e) {
    checkCheckbox(4);
});
Mousetrap.bind('ctrl+5', function(e) {
    checkCheckbox(5);
});
Mousetrap.bind('ctrl+6', function(e) {
    checkCheckbox(6);
});
Mousetrap.bind('ctrl+7', function(e) {
    checkCheckbox(7);
});
Mousetrap.bind('ctrl+8', function(e) {
    checkCheckbox(8);
});
Mousetrap.bind('ctrl+9', function(e) {
    checkCheckbox(9);
});
Mousetrap.bind('ctrl+0', function(e) {
    checkCheckbox(10);
});