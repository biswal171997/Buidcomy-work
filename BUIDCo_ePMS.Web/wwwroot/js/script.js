(function ($) {
    "use strict";

    $(document).ready(function () {


         //technical bid add date
            $('#addDatepick').click(function(event) {
                event.preventDefault();  
                $('#datePickerDiv').toggle();

                $(this).toggle(); 
            });
        

        // collapse icon toggle
        document.addEventListener('DOMContentLoaded', function() {
            var collapseElement = document.getElementById('showCorrigen');
            var downArrow = document.querySelector('.bi-chevron-down');
            var upArrow = document.querySelector('.bi-chevron-up');
     
            collapseElement.addEventListener('shown.bs.collapse', function() {
                downArrow.style.display = 'none';
                upArrow.style.display = 'inline-block';
            });
     
            collapseElement.addEventListener('hidden.bs.collapse', function() {
                downArrow.style.display = 'inline-block';
                upArrow.style.display = 'none';
            });
        });

        // collapse icon toggle


        /*** Tooltip Initialization ***/
        $('[data-bs-toggle="tooltip"]').tooltip(); // Initialize tooltips

        $("#proposalDate").datepicker({ dateFormat: 'dd-M-yy' });
        $("#txtfdrSubmitteddate").datepicker({ dateFormat: 'dd-M-yy' });
        $("#txtfdrloaDate").datepicker({ dateFormat: 'dd-M-yy' });
        $("#txttsLetterDate").datepicker({ dateFormat: 'dd-M-yy' });
        $( "#validDate" ).datepicker();
        $( "#startDate" ).datepicker();
        $( "#endDate" ).datepicker();
        $( "#corriGendum" ).datepicker();
        $( "#bidDate" ).datepicker();

        /*** Landing Menu Toggle ***/
        $(".toggle-menu").on("click", function () {
            $(".landing-menu").toggleClass("open");
        });
        $(".menu-back").on("click", function () {
            $(".landing-menu").toggleClass("open");
        });
        $('.loader-wrapper').fadeOut('slow', function () {
            $(this).remove();
        });


        /*** Search Input Behavior ***/
        $(".form-control-search input").keyup(function (e) {
            if (e.target.value) {
                $(".page-wrapper").addClass("offcanvas-bookmark");
            } else {
                $(".page-wrapper").removeClass("offcanvas-bookmark");
            }
        });


          /*** Nav Tabs Slider ***/
          const $navTabs = $("#pill-navtab .nav-tabs");
          const $slider = $("#pill-navtab .slider");
  
          // Update slider on tab click
          $navTabs.find("a").click(function () {
              const position = $(this).parent().position();
              const width = $(this).parent().width();
              $slider.css({ left: position.left, width: width });
          });
  
          // Set slider position and width for the active tab
          const activeTabWidth = $navTabs.find(".active").parent("li").width();
          const activeTabPosition = $navTabs.find(".active").position();
          //$slider.css({ left: activeTabPosition.left, width: activeTabWidth });

    });





})(jQuery);