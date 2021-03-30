console.log("Hello pluralsight");

var theForm = document.getElementById("theForm");
theForm.hidden = true;

var button = document.getElementById("buyButton");
button.addEventListener("click", function () {
    console.log("buying item");
});