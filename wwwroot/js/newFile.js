$(document).ready(function () {
    // Initially hide all input fields
    $('#gasolineCount, #gasolineDistance, #dieselCount, #dieselDistance, #cngCount, #cngDistance, #hybridCount, #hybridDistance, #electricCount, #electricDistance, #ethanolCount, #ethanolDistance').closest('.row').hide();

    // Function to toggle the input fields based on button clicks
    function toggleFields(buttonId, countId, distanceId) {
        let button = $('#' + buttonId);

        // Check if the button is already active
        if (button.hasClass('active')) {
            // If active, hide the fields and remove the active state
            $('#' + countId + ', #' + distanceId).closest('.row').hide();
            button.removeClass('active btn-dark').addClass('btn-outline-dark');
        } else {
            // Show the fields and activate the button
            $('#' + countId + ', #' + distanceId).closest('.row').show();
            button.addClass('active btn-dark').removeClass('btn-outline-dark');
        }
    }

    // Button click events for each type
    $('#btn-gasoline').click(function () {
        toggleFields('btn-gasoline', 'gasolineCount', 'gasolineDistance');
    });

    $('#btn-diesel').click(function () {
        toggleFields('btn-diesel', 'dieselCount', 'dieselDistance');
    });

    $('#btn-cng').click(function () {
        toggleFields('btn-cng', 'cngCount', 'cngDistance');
    });

    $('#btn-hybrid').click(function () {
        toggleFields('btn-hybrid', 'hybridCount', 'hybridDistance');
    });

    $('#btn-electric').click(function () {
        toggleFields('btn-electric', 'electricCount', 'electricDistance');
    });

    $('#btn-ethanol').click(function () {
        toggleFields('btn-ethanol', 'ethanolCount', 'ethanolDistance');
    });
});