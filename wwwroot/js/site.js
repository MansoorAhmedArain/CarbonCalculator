    document.addEventListener("DOMContentLoaded", function () {
        // Log session storage values to the console
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

        if (sessionStorage.getItem("Electriciy") != null) {
            console.log(sessionStorage.getItem("Electriciy"));
        }
    });
function calculateAndSaveEmissions() {
    $("#loader").show();

    const totalEmissions = {
        userId: 123,
        emissionsData: [
            {
                category: "MobileCombustion",
                result: parseFloat(sessionStorage.getItem("MobileCombustion") || 0)
            },
            {
                category: "StationaryCombustion",
                result: parseFloat(sessionStorage.getItem("StationaryCombustion") || 0)
            },
            {
                category: "ProcessEmission",
                result: parseFloat(sessionStorage.getItem("ProcessEmission") || 0)
            },
            {
                category: "RefrigerantEmissions",
                result: parseFloat(sessionStorage.getItem("RefrigerantEmissions") || 0)
            }
        ]
    };

    $.ajax({
        type: "POST",
        url: "/CarbonCalculator/SaveEmissions",
        data: JSON.stringify(totalEmissions), // Make sure this matches your C# class structure
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#loader").hide();
            if (response.success) {
                alert("Emissions calculated and saved successfully!");
            } else {
                alert("Error: " + response.message);
            }
        },
        error: function (error) {
            console.error("Error saving emissions:", error);
            alert("There was an error saving emissions.");
            $("#loader").hide();
        }
    });
}
