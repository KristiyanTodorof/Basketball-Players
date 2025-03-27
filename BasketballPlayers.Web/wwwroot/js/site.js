$(document).ready(function () {
    // 1. Hover effect on player rows
    $('.player-row').hover(
        function () {
            $(this).addClass('bg-light');
        },
        function () {
            $(this).removeClass('bg-light');
        }
    );

    // 2. Dynamic search/filter for players
    $('#playerSearch').on('keyup', function () {
        var value = $(this).val().toLowerCase();
        $(".player-row").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    // 3. Quick action buttons animation
    $('.btn-success, .btn-primary').on('mouseenter', function () {
        $(this).animate({
            opacity: 0.7
        }, 200);
    }).on('mouseleave', function () {
        $(this).animate({
            opacity: 1
        }, 200);
    });

    // 4. Add a dynamic counter for recent players
    function updatePlayerCount() {
        var playerCount = $('.player-row').length;
        $('#playerCount').text(playerCount);
    }
    updatePlayerCount();

    // 5. Confirm before adding a new player
    $('#addPlayerBtn').on('click', function (e) {
        if (!confirm('Are you sure you want to add a new player?')) {
            e.preventDefault();
        }
    });

    // 6. Toggle additional player information
    $('.player-details-toggle').on('click', function () {
        var $details = $(this).next('.player-additional-details');
        $details.slideToggle(300);
    });
})
