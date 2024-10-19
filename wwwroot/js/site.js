document.addEventListener("DOMContentLoaded", function () {
    if (sessionStorage.getItem("MobileCombustion") != null) {
        console.log(sessionStorage.getItem("MobileCombustion"));
    }

    if (sessionStorage.getItem("StationaryCombustion") != null) {
        console.log(sessionStorage.getItem("StationaryCombustion"));
    }


    if (sessionStorage.getItem("ProcessEmission") != null) {
        console.log(sessionStorage.getItem("ProcessEmission"));
    }

    if (sessionStorage.getItem("RefrigerantEmissions") != null) {
        console.log(sessionStorage.getItem("RefrigerantEmissions"));
    }
});