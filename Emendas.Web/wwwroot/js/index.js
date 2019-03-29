$(document).ready(function () {
    var form = jQuery("#theForm");
    form.hide();

    var button = $("#buyButton");
    button.on("click", function () {
        console.log("buying")
    });
    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("you clicked on " + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupform = $(".popup-form");

    $loginToggle.on("click", function () {
        $popupform.toggle(500);
    });
});