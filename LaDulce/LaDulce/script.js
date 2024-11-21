(function($) {


  $("#menu-filtros li a").click(function() {
    $("#menu-filtros li a").removeClass('active');
    $(this).addClass('active');

    var selectedFilter = $(this).data("filter");
    

    $(".menu-restaurante").fadeOut();

    setTimeout(function() {
      $(selectedFilter).slideDown();
      
    }, 300);
  });

  })(jQuery);

  ScrollReveal().reveal('.op1',{
    origin: 'left',
    duration :2000,
    distance:'20%'
    });