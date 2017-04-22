
       $(document).ready(function(){

           //Search box---------------------------------------------//
           $("#search-button").click(function () {
               $(".search-box").slideToggle();
               return false;
           });


           //Carousel's captions-----------------------------------//
           // initialization of first slide's caption
           $(".page-1").slideDown(1000, function () {
               $(".carousel-title-frame").fadeIn();
           });

           // removing captions from slides before change
           $("#myCarousel").on("slide.bs.carousel", function () {
               $(".carousel-title-background").slideUp();
               $(".carousel-title-frame").slideUp();
           });

           // initialization of new slide's caption after change
           $("#myCarousel").on("slid.bs.carousel", function () {
               $(".carousel-title-background").slideDown(1000, function () {
                   $(".carousel-title-frame").fadeIn();
               });
           });
           //-------------------------------------------------------//


           // carousel's speed
           $("#myCarousel").carousel({interval: 10000});

           // slide in elements on website (and prevent sliding when redirecting)
         
           var url = "http://simonoakwood-001-site1.ftempurl.com/";
           if (window.location.href == url)
           {
               $(window).scroll(function () {
                   $(".slideanim").each(function(){
                       var pos = $(this).offset().top;

                       var winTop = $(window).scrollTop();
                       if (pos < winTop + 550) {
                           $(this).addClass("slide2");
                       }
                   });
               });
           }
           else
           {
               $(".slideanim").css("visibility", "visible");
           }
           // Initialization of tooltip
           $('[data-toggle="tooltip"]').tooltip();


           $(".navbar a, footer a[href='#myPage']").on('click', function(event) {

               if (this.hash !== "") {

                   // Store hash
                   var hash = this.hash;

                   // Smooth page scroll
                   $('html, body').animate({
                       
                       scrollTop: $(hash).offset().top
                   }, 1500, function(){

                       // Add hash to URL when done scrolling (default click behavior)
                       window.location.hash = hash;
                   });

               } // End if
           });

       })

