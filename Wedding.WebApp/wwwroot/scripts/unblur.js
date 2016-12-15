// Triggers the collapse of the dropdown on 
// bootstraps collapsable menu after a person has clicked a link
$(document).ready(function () {

    $(".navbar-nav li a").click(function () {
        $(".navbar-collapse").collapse('hide');
    });

    $(document).on('click', 'button', function () {
        $(this).blur();
    });

    $(document).on('click', 'a', function () {
        $(this).blur();
    });
});