/*-----------------------------------------------------------------------------------

    Theme Name: Arco
    Description: The Multi-Purpose Onepage Template

-----------------------------------------------------------------------------------*/


$(function() {

    "use strict";

    var wind = $(window);



    // scrollIt
    $.scrollIt({
      upKey: 38,                // key code to navigate to the next section
      downKey: 40,              // key code to navigate to the previous section
      easing: 'swing',          // the easing function for animation
      scrollTime: 600,          // how long (in ms) the animation takes
      activeClass: 'active',    // class given to the active nav element
      onPageChange: null,       // function(pageIndex) that is called when page is changed
      topOffset: -80            // offste (in px) for fixed top navigation
    });



    // navbar scrolling background
    wind.on("scroll",function () {

        var bodyScroll = wind.scrollTop(),
            navbar = $(".navbar"),
            logo = $(".navbar .logo> img");

        if(bodyScroll > 100){

            navbar.addClass("nav-scroll");
            logo.attr('src', '/zamiux/img/logo-dark.png');

        }else{

            navbar.removeClass("nav-scroll");
            logo.attr('src', '/zamiux/img/logo-light.png');
        }
    });


    // close navbar-collapse when a  clicked
    $(".navbar-nav a").on('click', function () {
        $(".navbar-collapse").removeClass("show");
    });



    // progress bar
    wind.on('scroll', function () {
        $(".skill-progress .progres").each(function () {
            var bottom_of_object = 
            $(this).offset().top + $(this).outerHeight();
            var bottom_of_window = 
            $(window).scrollTop() + $(window).height();
            var myVal = $(this).attr('data-value');
            if(bottom_of_window > bottom_of_object) {
                $(this).css({
                  width : myVal
                });
            }
        });
    });



    // sections background image from data background
    var pageSection = $(".bg-img, section");
    pageSection.each(function(indx){
        
        if ($(this).attr("data-background")){
            $(this).css("background-image", "url(" + $(this).data("background") + ")");
        }
    });


    // === owl-carousel === //

    // Testimonials owlCarousel
    $('.carousel-single .owl-carousel').owlCarousel({
        items:1,
        loop:true,
        rtl:true,
        margin: 0,
        autoplay:true,
        smartSpeed:500,
        dots: false,
        nav: true,
        navText: ['<i class="fas fa-chevron-right"></i>','<i class="fas fa-chevron-left"></i>']
    });

    // Clients owlCarousel
    $('.clients .owl-carousel').owlCarousel({
        loop:true,
        rtl:true,
        margin: 60,
		dots: false,
		autoplay:true,
        responsiveClass:true,
        responsive:{
            0:{
                items:2
            },
            600:{
                items:3
            },
            1000:{
                items:6
            }
        }
    });

    // === End owl-carousel === //


    // magnificPopup
    $('.gallery').magnificPopup({
        delegate: '.popimg',
        type: 'image',
        gallery: {
            enabled: true,
			tPrev: 'قبلی',
			tNext: 'بعدی',
			tCounter: '%curr% از %total%'
		},
		image: {
			tError: '<a href="%url%">تصویر</a> بارگذاری نشد.'
		},
		ajax: {
			tError: '<a href="%url%">درخواست</a> ناموفق بود.'
		}
    });

    // YouTubePopUp
    $("a.vid").YouTubePopUp();


    // countUp
    $('.numbers .count').countUp({
        delay: 10,
        time: 1500
    });


    // accordion
    $(".accordion").on("click",".title", function () {

        $(this).next().slideDown();

        $(".accordion-info").not($(this).next()).slideUp();

    });

    $(".accordion").on("click",".item", function () {

        $(this).addClass("active").siblings().removeClass("active");

    });


});


// === window When Loading === //

$(window).on("load",function (){

    var wind = $(window);

    // Preloader
    $(".loading").fadeOut(500);


    // stellar
	wind.stellar({ horizontalScrolling: false });


    // isotope
    $('.gallery').isotope({
      // options
      itemSelector: '.items',
	  isOriginLeft: false
    });

    var $gallery = $('.gallery').isotope({
      // options
	  isOriginLeft: false
    });

    // filter items on button click
    $('.filtering').on( 'click', 'span', function() {

        var filterValue = $(this).attr('data-filter');

        $gallery.isotope({
		  filter: filterValue,
		  isOriginLeft: false
		});

    });

    $('.filtering').on( 'click', 'span', function() {

        $(this).addClass('active').siblings().removeClass('active');

    });


    // validator
	$.fn.validator.Constructor.FOCUS_OFFSET = $('nav.navbar').height() + 20;
	
    $('#contact-form').validator();
    $('#comment-form').validator();

	// contact form
    $('#contact-form').on('submit', function (e) {
        if (!e.isDefaultPrevented()) {
            var url = "php/contact.php";

            $.ajax({
                type: "POST",
                url: url,
                data: $(this).serialize(),
                success: function (data)
                {
                    var messageAlert = 'alert-' + data.type;
                    var messageText = data.message;

                    var alertBox = '<div class="alert ' + messageAlert + ' alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' + messageText + '</div>';
                    if (messageAlert && messageText) {
                        $('#contact-form').find('.messages').html(alertBox);
						if(data.type == 'success'){
							$('#contact-form')[0].reset();
						}
                    }
                }
            });
            return false;
        }
    });

});


// Slider 
$(document).ready(function() {

    var owl = $('.header .owl-carousel');


    // Slider owlCarousel
    $('.slider .owl-carousel').owlCarousel({
        items: 1,
        loop:true,
        rtl:true,
        margin: 0,
        autoplay:true,
        smartSpeed:500
    });

    // Slider owlCarousel
    $('.slider-fade .owl-carousel').owlCarousel({
        items: 1,
        loop:true,
        rtl:true,
        margin: 0,
        autoplay:true,
        smartSpeed:500,
        animateOut: 'fadeOut'
    });

	// Slider Drag
	owl.on('drag.owl.carousel', function() {

		owl.find('.owl-item').not('.active').find('h4').addClass('d-none');
		owl.find('.owl-item').not('.active').find('h1').addClass('d-none');
		owl.find('.owl-item').not('.active').find('p').addClass('d-none');
		owl.find('.owl-item').not('.active').find('.butn').addClass('d-none');

		var not_cloned = owl.find('.owl-item').not('.cloned');

		if(owl.find('.owl-item.active').is( not_cloned.last().next() )){
			not_cloned.first().find('h4').removeClass('d-none');
			not_cloned.first().find('h1').removeClass('d-none');
			not_cloned.first().find('p').removeClass('d-none');
			not_cloned.first().find('.butn').removeClass('d-none');
		}

		else if(owl.find('.owl-item.active').is( not_cloned.first() )){
			not_cloned.last().next().find('h4').removeClass('d-none');
			not_cloned.last().next().find('h1').removeClass('d-none');
			not_cloned.last().next().find('p').removeClass('d-none');
			not_cloned.last().next().find('.butn').removeClass('d-none');
		}
	});

	// Slider Change
    owl.on('changed.owl.carousel', function(event) {
        var item = event.item.index;     // Position of the current item
		owl.find('.owl-item h4').removeClass('animated fadeInRight d-none');
		owl.find('.owl-item h1').removeClass('animated fadeInLeft d-none');
		owl.find('.owl-item p').removeClass('animated fadeInUp d-none');
		owl.find('.owl-item .butn').removeClass('animated zoomIn d-none');
		owl.find('.owl-item').eq(item).find('h4').addClass('animated fadeInRight');
		owl.find('.owl-item').eq(item).find('h1').addClass('animated fadeInLeft');
		owl.find('.owl-item').eq(item).find('p').addClass('animated fadeInUp');
		owl.find('.owl-item').eq(item).find('.butn').addClass('animated zoomIn');
    });

});

// Detect IE
var isIE = /*@cc_on!@*/false || !!document.documentMode;

if(isIE){
	$('body').addClass('is_ie');
}
